using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Trade.Header
{
  public class HeadersService : Service
  {
    public HeadersResponse Get(Headers request)
    {
      HeadersResponse response = new HeadersResponse();

      if (!request.Ids.Any())
      {
        response.Headers.AddRange(Datas.Instance.DataStorage.Headers.Where(item =>
          (request.ActivityId == 0 || item.ActivityId == request.ActivityId) &&
          (!request.Date.HasValue || (request.Date >= item.Date && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value))) &&
          (string.IsNullOrWhiteSpace(request.Description) || item.Description.ToLower().Contains(request.Description.ToLower())) &&
          (request.HeaderStatusId == 0 || item.HeaderStatusId == request.HeaderStatusId) &&
          (!request.IsSell || item.IsSell) &&
          (string.IsNullOrWhiteSpace(request.Reference) || item.Reference.ToLower().Contains(request.Reference.ToLower())) &&
          (request.UserId == 0 || item.UserId == request.UserId)
          ));
      }
      else
      {
        response.Headers.AddRange(Datas.Instance.DataStorage.Headers.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public Bm2s.Poco.Common.Trade.Header Post(Headers request)
    {
      if (request.Header.Id > 0)
      {
        Datas.Instance.DataStorage.Headers[request.Header.Id] = request.Header;
      }
      else
      {
        Datas.Instance.DataStorage.Headers.Add(request.Header);
      }
      return request.Header;
    }
  }
}
