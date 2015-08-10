using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Trade.HeaderStatus
{
  public class HeaderStatusesService : Service
  {
    public object Get(HeaderStatuses request)
    {
      HeaderStatusesResponse response = new HeaderStatusesResponse();

      if (!request.Ids.Any())
      {
        response.HeaderStatuses.AddRange(Datas.Instance.DataStorage.HeaderStatuses.Where(item =>
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value))) &&
          (!request.InterveneOnStock || item.InterveneOnStock) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower()))
          ));
      }
      else
      {
        response.HeaderStatuses.AddRange(Datas.Instance.DataStorage.HeaderStatuses.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(HeaderStatuses request)
    {
      if (request.HeaderStatus.Id > 0)
      {
        Datas.Instance.DataStorage.HeaderStatuses[request.HeaderStatus.Id] = request.HeaderStatus;
      }
      else
      {
        Datas.Instance.DataStorage.HeaderStatuses.Add(request.HeaderStatus);
      }
      return request.HeaderStatus;
    }
  }
}
