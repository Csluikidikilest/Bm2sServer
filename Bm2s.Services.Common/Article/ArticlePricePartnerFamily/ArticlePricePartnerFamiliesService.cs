using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Article.Article;
using Bm2s.Response.Common.Article.ArticlePricePartnerFamily;
using Bm2s.Response.Common.Partner.PartnerFamily;
using Bm2s.Services.Common.Article.Article;
using Bm2s.Services.Common.Partner.PartnerFamily;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Article.ArticlePricePartnerFamily
{
  public class ArticlePricePartnerFamiliesService : Service
  {
    public ArticlePricePartnerFamiliesResponse Get(ArticlePricePartnerFamilies request)
    {
      ArticlePricePartnerFamiliesResponse response = new ArticlePricePartnerFamiliesResponse();
      List<Bm2s.Data.Common.BLL.Article.ArticlePricePartnerFamily> items = new List<Data.Common.BLL.Article.ArticlePricePartnerFamily>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.ArticlePricePartnerFamilies.Where(item =>
          (request.PartnerFamilyId == 0 || item.PartnerFamilyId == request.PartnerFamilyId) &&
          (request.ArticleId == 0 || item.ArticleId == request.ArticleId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.ArticlePricePartnerFamilies.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Article.ArticlePricePartnerFamily()
                        {
                          Article = new ArticlesService().Get(new Articles() { Ids = new List<int>() { item.ArticleId } }).Articles.FirstOrDefault(),
                          EndingDate = item.EndingDate,
                          Id = item.Id,
                          Multiplier = item.Multiplier,
                          PartnerFamily = new PartnerFamiliesService().Get(new PartnerFamilies() { Ids = new List<int>() { item.PartnerFamilyId } }).PartnerFamilies.FirstOrDefault(),
                          Price = item.Price,
                          StartingDate = item.StartingDate
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.ArticlePricePartnerFamilies.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.ArticlePricePartnerFamilies.AddRange(collection);
      }

      try {
      response.PagesCount = collection.Count() / response.ArticlePricePartnerFamilies.Count + (collection.Count() % response.ArticlePricePartnerFamilies.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public ArticlePricePartnerFamiliesResponse Post(ArticlePricePartnerFamilies request)
    {
      if (request.ArticlePricePartnerFamily.Id > 0)
      {
        Bm2s.Data.Common.BLL.Article.ArticlePricePartnerFamily item = Datas.Instance.DataStorage.ArticlePricePartnerFamilies[request.ArticlePricePartnerFamily.Id];
        item.ArticleId = request.ArticlePricePartnerFamily.Article.Id;
        item.EndingDate = request.ArticlePricePartnerFamily.EndingDate;
        item.Multiplier = request.ArticlePricePartnerFamily.Multiplier;
        item.PartnerFamilyId = request.ArticlePricePartnerFamily.PartnerFamily.Id;
        item.Price = request.ArticlePricePartnerFamily.Price;
        item.StartingDate = request.ArticlePricePartnerFamily.StartingDate;
        Datas.Instance.DataStorage.ArticlePricePartnerFamilies[request.ArticlePricePartnerFamily.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Article.ArticlePricePartnerFamily item = new Data.Common.BLL.Article.ArticlePricePartnerFamily()
        {
          ArticleId = request.ArticlePricePartnerFamily.Article.Id,
          EndingDate = request.ArticlePricePartnerFamily.EndingDate,
          Multiplier = request.ArticlePricePartnerFamily.Multiplier,
          PartnerFamilyId = request.ArticlePricePartnerFamily.PartnerFamily.Id,
          Price = request.ArticlePricePartnerFamily.Price,
          StartingDate = request.ArticlePricePartnerFamily.StartingDate
        };

        Datas.Instance.DataStorage.ArticlePricePartnerFamilies.Add(item);
        request.ArticlePricePartnerFamily.Id = item.Id;
      }

      ArticlePricePartnerFamiliesResponse response = new ArticlePricePartnerFamiliesResponse();
      response.ArticlePricePartnerFamilies.Add(request.ArticlePricePartnerFamily);
      return response;
    }

    public ArticlePricePartnerFamiliesResponse Delete(ArticlePricePartnerFamilies request)
    {
      Bm2s.Data.Common.BLL.Article.ArticlePricePartnerFamily item = Datas.Instance.DataStorage.ArticlePricePartnerFamilies.FirstOrDefault(nomenclature => nomenclature.Id == request.ArticlePricePartnerFamily.Id);
      if (item != null)
      {
        Datas.Instance.DataStorage.ArticlePricePartnerFamilies.Remove(item);
      }

      ArticlePricePartnerFamiliesResponse response = new ArticlePricePartnerFamiliesResponse();
      response.ArticlePricePartnerFamilies.Add(request.ArticlePricePartnerFamily);
      return response;
    }
  }
}
