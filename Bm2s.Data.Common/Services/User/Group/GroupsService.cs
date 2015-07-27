using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.User.Group
{
  public class GroupsService : Service
  {
    public object Get(Groups request)
    {
      GroupsResponse response = new GroupsResponse();

      if (!request.Ids.Any())
      {
        response.Groups.AddRange(Datas.Instance.DataStorage.Groups);
      }
      else
      {
        response.Groups.AddRange(Datas.Instance.DataStorage.Groups.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(Groups request)
    {
      if (request.Group.Id > 0)
      {
        Datas.Instance.DataStorage.Groups[request.Group.Id] = request.Group;
      }
      else
      {
        Datas.Instance.DataStorage.Groups.Add(request.Group);
      }
      return request.Group;
    }
  }
}
