using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Parameter.AffairHeader
{
  class AffairHeadersService : Service
  {
    public object Get(AffairHeaders request)
    {
      AffairHeadersResponse response = new AffairHeadersResponse();

      if (!request.Ids.Any())
      {
        response.AffairHeaders.AddRange(Datas.Instance.DataStorage.AffairHeaders);
      }
      else
      {
        response.AffairHeaders.AddRange(Datas.Instance.DataStorage.AffairHeaders.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(AffairHeaders request)
    {
      if (request.AffairHeader.Id > 0)
      {
        Datas.Instance.DataStorage.AffairHeaders[request.AffairHeader.Id] = request.AffairHeader;
      }
      else
      {
        Datas.Instance.DataStorage.AffairHeaders.Add(request.AffairHeader);
      }
      return request.AffairHeader;
    }
  }
}
