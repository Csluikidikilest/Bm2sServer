using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Parameter.Country;
using Bm2s.Response.Common.Parameter.CountryCurrency;
using Bm2s.Response.Common.Parameter.Unit;
using Bm2s.Services.Common.Parameter.Country;
using Bm2s.Services.Common.Parameter.Unit;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.CountryCurrency
{
  public class CountryCurrenciesService : Service
  {
    public CountryCurrenciesResponse Get(CountryCurrencies request)
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

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Parameter.CountryCurrency()
                        {
                          Country = new CountriesService().Get(new Countries() { Ids = new List<int>() { item.CountryId } }).Countries.FirstOrDefault(),
                          EndingDate = item.EndingDate,
                          Id = item.Id,
                          StartingDate = item.StartingDate,
                          Unit = new UnitsService().Get(new Units() { Ids = new List<int>() { item.UnitId } }).Units.FirstOrDefault()
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.CountryCurrencies.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.CountryCurrencies.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.CountryCurrencies.Count + (collection.Count() % response.CountryCurrencies.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public CountryCurrenciesResponse Post(CountryCurrencies request)
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

      CountryCurrenciesResponse response = new CountryCurrenciesResponse();
      response.CountryCurrencies.Add(request.CountryCurrency);
      return response;
    }
  }
}
