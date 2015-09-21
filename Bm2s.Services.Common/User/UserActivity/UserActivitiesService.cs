using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Parameter.Activity;
using Bm2s.Response.Common.User.User;
using Bm2s.Response.Common.User.UserActivity;
using Bm2s.Services.Common.Parameter.Activity;
using Bm2s.Services.Common.User.User;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.User.UserActivity
{
  public class UserActivitiesService : Service
  {
    public UserActivitiesResponse Get(UserActivities request)
    {
      UserActivitiesResponse response = new UserActivitiesResponse();
      List<Bm2s.Data.Common.BLL.User.UserActivity> items = new List<Data.Common.BLL.User.UserActivity>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.UserActivities.Where(item =>
          (request.ActivityId == 0 || item.ActivityId == request.ActivityId) &&
          (request.UserId == 0 || item.UserId == request.UserId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.UserActivities.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.User.UserActivity()
                        {
                          Activity = new ActivitiesService().Get(new Activities() { Ids = new List<int>() { item.ActivityId } }).Activities.FirstOrDefault(),
                          Id = item.Id,
                          IsDefault = item.IsDefault,
                          User = new UsersService().Get(new Users() { Ids = new List<int>() { item.UserId } }).Users.FirstOrDefault()
                        }).AsQueryable().OrderBy(request.Order, request.AscendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.UserActivities.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.UserActivities.AddRange(collection);
      }
      response.PagesCount = collection.Count() / response.UserActivities.Count + (collection.Count() % response.UserActivities.Count > 0 ? 1 : 0);

      return response;
    }

    public UserActivitiesResponse Post(UserActivities request)
    {
      if (request.UserActivity.Id > 0)
      {
        Bm2s.Data.Common.BLL.User.UserActivity item = Datas.Instance.DataStorage.UserActivities[request.UserActivity.Id];
        item.ActivityId = request.UserActivity.Activity.Id;
        item.IsDefault = request.UserActivity.IsDefault;
        item.UserId = request.UserActivity.User.Id;
        Datas.Instance.DataStorage.UserActivities[request.UserActivity.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.User.UserActivity item = new Data.Common.BLL.User.UserActivity()
        {
          ActivityId = request.UserActivity.Activity.Id,
          IsDefault = request.UserActivity.IsDefault,
          UserId = request.UserActivity.User.Id
        };

        Datas.Instance.DataStorage.UserActivities.Add(item);
        request.UserActivity.Id = item.Id;
      }

      UserActivitiesResponse response = new UserActivitiesResponse();
      response.UserActivities.Add(request.UserActivity);
      return response;
    }
  }
}
