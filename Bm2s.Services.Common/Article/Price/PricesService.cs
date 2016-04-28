using System;
using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Article.Article;
using Bm2s.Response.Common.Article.Price;
using Bm2s.Services.Common.Article.Article;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Article.Price
{
  public class PricesService : Service
  {
    public PricesResponse Get(Prices request)
    {
      PricesResponse response = new PricesResponse();
      List<Bm2s.Data.Common.BLL.Article.Pric> items = new List<Data.Common.BLL.Article.Pric>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Prices.Where(item =>
          (request.ArticleId == 0 || item.ArtId == request.ArticleId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Prices.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Article.Price()
                        {
                          Article = new ArticlesService().Get(new Articles() { Ids = new List<int>() { item.ArtId } }).Articles.FirstOrDefault(),
                          BasePrice = Convert.ToDecimal(item.BasePrice),
                          EndingDate = item.EndingDate,
                          Id = item.Id,
                          StartingDate = item.StartingDate
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.Prices.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.Prices.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.Prices.Count + (collection.Count() % response.Prices.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public PricesResponse Post(Prices request)
    {
      if (request.Price.Id > 0)
      {
        Bm2s.Data.Common.BLL.Article.Pric item = Datas.Instance.DataStorage.Prices[request.Price.Id];
        item.ArtId = request.Price.Article.Id;
        item.BasePrice = Convert.ToDouble(request.Price.BasePrice);
        item.EndingDate = request.Price.EndingDate;
        item.StartingDate = request.Price.StartingDate;
        Datas.Instance.DataStorage.Prices[request.Price.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Article.Pric item = new Data.Common.BLL.Article.Pric()
        {
          ArtId = request.Price.Article.Id,
          BasePrice = Convert.ToDouble(request.Price.BasePrice),
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

    public PricesResponse Delete(Prices request)
    {
      Bm2s.Data.Common.BLL.Article.Pric item = Datas.Instance.DataStorage.Prices[request.Price.Id];
      item.EndingDate = DateTime.Now;
      Datas.Instance.DataStorage.Prices[item.Id] = item;

      PricesResponse response = new PricesResponse();
      response.Prices.Add(request.Price);
      return response;
    }
  }
}
