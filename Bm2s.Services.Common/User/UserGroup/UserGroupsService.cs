using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.User.UserGroup
{
  public class UserGroupsService : Service
  {
    public object Get(UserGroups request)
    {
      UserGroupsResponse response = new UserGroupsResponse();

      if (!request.Ids.Any())
      {
        response.UserGroups.AddRange(Datas.Instance.DataStorage.UserGroups.Where(item =>
          (request.GroupId == 0 || item.GroupId == request.GroupId) &&
          (request.UserId == 0 || item.UserId == request.UserId)
          ));
      }
      else
      {
        response.UserGroups.AddRange(Datas.Instance.DataStorage.UserGroups.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(UserGroups request)
    {
      if (request.UserGroup.Id > 0)
      {
        Datas.Instance.DataStorage.UserGroups[request.UserGroup.Id] = request.UserGroup;
      }
      else
      {
        Datas.Instance.DataStorage.UserGroups.Add(request.UserGroup);
      }
      return request.UserGroup;
    }
  }
}
