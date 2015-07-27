using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Parameter.InventoryHeader
{
  public class InventoryHeadersService : Service
  {
    public object Get(InventoryHeaders request)
    {
      InventoryHeadersResponse response = new InventoryHeadersResponse();

      if (!request.Ids.Any())
      {
        response.InventoryHeaders.AddRange(Datas.Instance.DataStorage.InventoryHeaders);
      }
      else
      {
        response.InventoryHeaders.AddRange(Datas.Instance.DataStorage.InventoryHeaders.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(InventoryHeaders request)
    {
      if (request.InventoryHeader.Id > 0)
      {
        Datas.Instance.DataStorage.InventoryHeaders[request.InventoryHeader.Id] = request.InventoryHeader;
      }
      else
      {
        Datas.Instance.DataStorage.InventoryHeaders.Add(request.InventoryHeader);
      }
      return request.InventoryHeader;
    }
  }
}
