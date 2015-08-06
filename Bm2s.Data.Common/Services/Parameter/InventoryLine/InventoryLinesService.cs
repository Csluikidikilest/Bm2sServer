using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Parameter.InventoryLine
{
  public class InventoryLinesService : Service
  {
    public object Get(InventoryLines request)
    {
      InventoryLinesResponse response = new InventoryLinesResponse();

      if (!request.Ids.Any())
      {
        response.InventoryLines.AddRange(Datas.Instance.DataStorage.InventoryLines.Where(item =>
          (request.ArticleId == 0 || item.ArticleId == request.ArticleId) &&
          (request.InventoryHeaderId == 0 || item.InventoryHeaderId == request.InventoryHeaderId)
          ));
      }
      else
      {
        response.InventoryLines.AddRange(Datas.Instance.DataStorage.InventoryLines.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(InventoryLines request)
    {
      if (request.InventoryLine.Id > 0)
      {
        Datas.Instance.DataStorage.InventoryLines[request.InventoryLine.Id] = request.InventoryLine;
      }
      else
      {
        Datas.Instance.DataStorage.InventoryLines.Add(request.InventoryLine);
      }
      return request.InventoryLine;
    }
  }
}
