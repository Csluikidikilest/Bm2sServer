using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Trade.HeaderFreeReference
{
  public class HeaderFreeReferencesService : Service
  {
    public object Get(HeaderFreeReferences request)
    {
      HeaderFreeReferencesResponse response = new HeaderFreeReferencesResponse();

      if (!request.Ids.Any())
      {
        response.HeaderFreeReferences.AddRange(Datas.Instance.DataStorage.HeaderFreeReferences);
      }
      else
      {
        response.HeaderFreeReferences.AddRange(Datas.Instance.DataStorage.HeaderFreeReferences.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(HeaderFreeReferences request)
    {
      if (request.HeaderFreeReference.Id > 0)
      {
        Datas.Instance.DataStorage.HeaderFreeReferences[request.HeaderFreeReference.Id] = request.HeaderFreeReference;
      }
      else
      {
        Datas.Instance.DataStorage.HeaderFreeReferences.Add(request.HeaderFreeReference);
      }
      return request.HeaderFreeReference;
    }
  }
}
