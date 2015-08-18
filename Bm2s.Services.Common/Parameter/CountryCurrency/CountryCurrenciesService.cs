using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Services.Common.Parameter.Country;
using Bm2s.Services.Common.Parameter.Unit;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.CountryCurrency
{
  public class CountryCurrenciesService : Service
  {
    public object Get(CountryCurrencies request)
    {
      CountryCurrenciesResponse response = new CountryCurrenciesResponse();
      List<Bm2s.Data.Common.BLL.Parameter.CountryCurrency> items = new List<Data.Common.BLL.Parameter.CountryCurrency>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.CountryCurrencies.Where(item =>
          (request.CountryId == 0 || item.CountryId == request.CountryId) &&
          (request.UnitId == 0 || item.UnitId == request.UnitId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.CountryCurrencies.Where(item => request.Ids.Contains(item.Id)));
      }

      response.CountryCurrencies.AddRange(from item in items
                                          select new Bm2s.Poco.Common.Parameter.CountryCurrency()
                                          {
                                            Country = new CountriesService().Get(new Countries() { Ids = new List<int>() { item.CountryId } }).Countries.FirstOrDefault(),
                                            EndingDate = item.EndingDate,
                                            Id = item.Id,
                                            StartingDate = item.StartingDate,
                                            Unit = new UnitsService().Get(new Units() { Ids = new List<int>() { item.UnitId } }).Units.FirstOrDefault()
                                          });

      return response;
    }

    public Bm2s.Poco.Common.Parameter.CountryCurrency Post(CountryCurrencies request)
    {
      if (request.CountryCurrency.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.CountryCurrency item = Datas.Instance.DataStorage.CountryCurrencies[request.CountryCurrency.Id];
        item.CountryId = request.CountryCurrency.Country.Id;
        item.EndingDate = request.CountryCurrency.EndingDate;
        item.StartingDate = request.CountryCurrency.StartingDate;
        item.UnitId = request.CountryCurrency.Unit.Id;
        Datas.Instance.DataStorage.CountryCurrencies[request.CountryCurrency.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.CountryCurrency item = new Data.Common.BLL.Parameter.CountryCurrency()
        {
          CountryId = request.CountryCurrency.Country.Id,
          EndingDate = request.CountryCurrency.EndingDate,
          StartingDate = request.CountryCurrency.StartingDate,
          UnitId = request.CountryCurrency.Unit.Id
        };

        Datas.Instance.DataStorage.CountryCurrencies.Add(item);
        request.CountryCurrency.Id = item.Id;
      }

      return request.CountryCurrency;
    }
  }
}
