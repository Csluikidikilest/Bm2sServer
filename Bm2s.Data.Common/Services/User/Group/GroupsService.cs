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
        response.Groups.AddRange(Datas.Instance.DataStorage.Groups.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower()))
          ));
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
