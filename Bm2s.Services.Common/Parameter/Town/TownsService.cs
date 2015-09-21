using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Parameter.Country;
using Bm2s.Response.Common.Parameter.Town;
using Bm2s.Services.Common.Parameter.Country;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.Town
{
  public class TownsService : Service
  {
    public TownsResponse Get(Towns request)
    {
      TownsResponse response = new TownsResponse();
      List<Bm2s.Data.Common.BLL.Parameter.Town> items = new List<Data.Common.BLL.Parameter.Town>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Towns.Where(item =>
          (request.CountryId == 0 || item.CountryId == request.CountryId) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.ZipCode) || item.ZipCode.ToLower().Contains(request.ZipCode.ToLower())) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Towns.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Parameter.Town()
                        {
                          Country = new CountriesService().Get(new Countries() { Ids = new List<int>() { item.CountryId } }).Countries.FirstOrDefault(),
                          EndingDate = item.EndingDate,
                          Id = item.Id,
                          Name = item.Name,
                          StartingDate = item.StartingDate,
                          ZipCode = item.ZipCode
                        }).AsQueryable().OrderBy(request.Order, request.AscendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.Towns.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.Towns.AddRange(collection);
      }
      response.PagesCount = collection.Count() / response.Towns.Count + (collection.Count() % response.Towns.Count > 0 ? 1 : 0);

      return response;
    }

    public TownsResponse Post(Towns request)
    {
      if (request.Town.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.Town item = Datas.Instance.DataStorage.Towns[request.Town.Id];
        item.CountryId = request.Town.Country.Id;
        item.EndingDate = request.Town.EndingDate;
        item.Name = request.Town.Name;
        item.StartingDate = request.Town.StartingDate;
        item.ZipCode = request.Town.ZipCode;
        Datas.Instance.DataStorage.Towns[request.Town.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.Town item = new Data.Common.BLL.Parameter.Town() {
        CountryId = request.Town.Country.Id,
        EndingDate = request.Town.EndingDate,
        Name = request.Town.Name,
        StartingDate = request.Town.StartingDate,
        ZipCode = request.Town.ZipCode
        };

        Datas.Instance.DataStorage.Towns.Add(item);
        request.Town.Id = item.Id;
      }

      TownsResponse response = new TownsResponse();
      response.Towns.Add(request.Town);
      return response;
    }
  }
}
