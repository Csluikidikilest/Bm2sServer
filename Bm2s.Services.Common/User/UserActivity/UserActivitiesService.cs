using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.User.UserActivity
{
  public class UserActivitiesService : Service
  {
    public object Get(UserActivities request)
    {
      UserActivitiesResponse response = new UserActivitiesResponse();

      if (!request.Ids.Any())
      {
        response.UserActivities.AddRange(Datas.Instance.DataStorage.UserActivities.Where(item =>
          (request.ActivityId == 0 || item.ActivityId == request.ActivityId) &&
          (request.UserId == 0 || item.UserId == request.UserId)
          ));
      }
      else
      {
        response.UserActivities.AddRange(Datas.Instance.DataStorage.UserActivities.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(UserActivities request)
    {
      if (request.UserActivity.Id > 0)
      {
        Datas.Instance.DataStorage.UserActivities[request.UserActivity.Id] = request.UserActivity;
      }
      else
      {
        Datas.Instance.DataStorage.UserActivities.Add(request.UserActivity);
      }
      return request.UserActivity;
    }
  }
}
