using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Services.Common.Article.Article;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Article.Price
{
  public class PricesService : Service
  {
    public PricesResponse Get(Prices request)
    {
      PricesResponse response = new PricesResponse();
      List<Bm2s.Data.Common.BLL.Article.Price> items = new List<Data.Common.BLL.Article.Price>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Prices.Where(item =>
          (request.ArticleId == 0 || item.ArticleId == request.ArticleId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Prices.Where(item => request.Ids.Contains(item.Id)));
      }

      response.Prices.AddRange(from item in items
                               select new Bm2s.Poco.Common.Article.Price()
                               {
                                 Article = new ArticlesService().Get(new Articles() { Ids = new List<int>() { item.ArticleId} }).Articles.FirstOrDefault(),
                                 BasePrice = item.BasePrice,
                                 EndingDate = item.EndingDate,
                                 Id = item.Id,
                                 StartingDate = item.StartingDate
                               });

      return response;
    }

    public PricesResponse Post(Prices request)
    {
      if (request.Price.Id > 0)
      {
        Bm2s.Data.Common.BLL.Article.Price item = Datas.Instance.DataStorage.Prices[request.Price.Id];
        item.ArticleId = request.Price.Article.Id;
        item.BasePrice = request.Price.BasePrice;
        item.EndingDate = request.Price.EndingDate;
        item.StartingDate = request.Price.StartingDate;
        Datas.Instance.DataStorage.Prices[request.Price.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Article.Price item = new Data.Common.BLL.Article.Price()
        {
          ArticleId = request.Price.Article.Id,
          BasePrice = request.Price.BasePrice,
          EndingDate = request.Price.EndingDate,
          StartingDate = request.Price.StartingDate
        };

        Datas.Instance.DataStorage.Prices.Add(item);
        request.Price.Id = item.Id;
      }

      PricesResponse response = new PricesResponse();
      response.Prices.Add(request.Price);
      return response;
    }
  }
}
