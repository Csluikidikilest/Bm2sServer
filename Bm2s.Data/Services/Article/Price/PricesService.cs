using Bm2s.Data.Utils;
using ServiceStack.ServiceInterface;
using System.Collections.Generic;
using System.Linq;

namespace Bm2s.Data.Services.Article.Price
{
  public class PricesService : Service
  {
    public object Get(Prices request)
    {
      PricesResponse response = new PricesResponse();

      if (!request.Ids.Any())
      {
        response.Prices.AddRange(Datas.Instance.DataStorage.Prices);
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
