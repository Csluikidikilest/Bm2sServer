using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Trade.Header
{
  public class HeadersService : Service
  {
    public object Get(Headers request)
    {
      HeadersResponse response = new HeadersResponse();

      if (!request.Ids.Any())
      {
        response.Headers.AddRange(Datas.Instance.DataStorage.Headers);
      }
      else
      {
        response.Headers.AddRange(Datas.Instance.DataStorage.Headers.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(Headers request)
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
