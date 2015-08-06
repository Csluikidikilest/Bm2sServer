using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Parameter.Affair
{
  public class AffairsService : Service
  {
    public object Get(Affairs request)
    {
      AffairsResponse response = new AffairsResponse();

      if (!request.Ids.Any())
      {
        response.Affairs.AddRange(Datas.Instance.DataStorage.Affairs.Where(item =>
          (request.ActivityId == 0 || item.ActivityId == request.ActivityId) &&
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.Contains(request.Code)) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.Contains(request.Name)) &&
          (request.UserId == 0 || item.UserId == request.UserId)
          ));
      }
      else
      {
        response.Affairs.AddRange(Datas.Instance.DataStorage.Affairs.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(Affairs request)
    {
      if (request.Affair.Id > 0)
      {
        Datas.Instance.DataStorage.Affairs[request.Affair.Id] = request.Affair;
      }
      else
      {
        Datas.Instance.DataStorage.Affairs.Add(request.Affair);
      }
      return request.Affair;
    }
  }
}
