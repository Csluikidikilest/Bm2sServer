using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Parameter.Activity;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.Activity
{
  public class ActivitiesService : Service
  {
    public ActivitiesResponse Get(Activities request)
    {
      ActivitiesResponse response = new ActivitiesResponse();
      List<Bm2s.Data.Common.BLL.Parameter.Activity> items = new List<Data.Common.BLL.Parameter.Activity>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Activities.Where(item =>
          (string.IsNullOrWhiteSpace(request.CompanyName) || item.CompanyName.ToLower().Contains(request.CompanyName.ToLower()))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Activities.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Parameter.Activity()
                        {
                          Address1 = item.Address1,
                          Address2 = item.Address2,
                          Address3 = item.Address3,
                          CompanyName = item.CompanyName,
                          CountryName = item.CountryName,
                          Id = item.Id,
                          TownName = item.TownName,
                          TownZipCode = item.TownZipCode
                        }).AsQueryable().OrderBy(request.Order, request.AscendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.Activities.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.Activities.AddRange(collection);
      }
      response.PagesCount = collection.Count() / response.Activities.Count + (collection.Count() % response.Activities.Count > 0 ? 1 : 0);

      return response;
    }

    public ActivitiesResponse Post(Activities request)
    {
      if (request.Activity.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.Activity item = Datas.Instance.DataStorage.Activities[request.Activity.Id];
        item.Address1 = request.Activity.Address1;
        item.Address2 = request.Activity.Address2;
        item.Address3 = request.Activity.Address3;
        item.CompanyName = request.Activity.CompanyName;
        item.CountryName = request.Activity.CountryName;
        item.TownName = request.Activity.TownName;
        item.TownZipCode = request.Activity.TownZipCode;
        Datas.Instance.DataStorage.Activities[request.Activity.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.Activity item = new Data.Common.BLL.Parameter.Activity()
        {
          Address1 = request.Activity.Address1,
          Address2 = request.Activity.Address2,
          Address3 = request.Activity.Address3,
          CompanyName = request.Activity.CompanyName,
          CountryName = request.Activity.CountryName,
          TownName = request.Activity.TownName,
          TownZipCode = request.Activity.TownZipCode
        };

        Datas.Instance.DataStorage.Activities.Add(item);
        request.Activity.Id = item.Id;
      }

      ActivitiesResponse response = new ActivitiesResponse();
      response.Activities.Add(request.Activity);
      return response;
    }
  }
}
