using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System.Collections.Generic;
using System.Linq;

namespace Bm2s.Services.Common.Article.Price
{
  public class PricesService : Service
  {
    public object Get(Prices request)
    {
      PricesResponse response = new PricesResponse();

      if (!request.Ids.Any())
      {
        response.Prices.AddRange(Datas.Instance.DataStorage.Prices.Where(item =>
          (request.ArticleId == 0 || item.ArticleId == request.ArticleId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        response.Prices.AddRange(Datas.Instance.DataStorage.Prices.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(Prices request)
    {
      if (request.Price.Id > 0)
      {
        Datas.Instance.DataStorage.Prices[request.Price.Id] = request.Price;
      }
      else
      {
        Datas.Instance.DataStorage.Prices.Add(request.Price);
      }
      return request.Price;
    }
  }
}
