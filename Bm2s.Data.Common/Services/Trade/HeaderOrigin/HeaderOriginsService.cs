using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Trade.HeaderOrigin
{
  public class HeaderOriginsService : Service
  {
    public object Get(HeaderOrigins request)
    {
      HeaderOriginsResponse response = new HeaderOriginsResponse();

      if (!request.Ids.Any())
      {
        response.HeaderOrigins.AddRange(Datas.Instance.DataStorage.HeaderOrigins);
      }
      else
      {
        response.HeaderOrigins.AddRange(Datas.Instance.DataStorage.HeaderOrigins.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(HeaderOrigins request)
    {
      if (request.HeaderOrigin.Id > 0)
      {
        Datas.Instance.DataStorage.HeaderOrigins[request.HeaderOrigin.Id] = request.HeaderOrigin;
      }
      else
      {
        Datas.Instance.DataStorage.HeaderOrigins.Add(request.HeaderOrigin);
      }
      return request.HeaderOrigin;
    }
  }
}
