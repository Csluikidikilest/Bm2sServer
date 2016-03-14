using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Services.Common.Article.Article;
using Bm2s.Services.Common.Partner.Partner;
using Bm2s.Response.Common.Article.ArticlePriceParner;
using Bm2s.Response.Common.Article.Article;
using Bm2s.Response.Common.Partner.Partner;

namespace Bm2s.Services.Common.Article.ArticlePriceParner
{
  public class ArticlePricePartnersService : Service
  {
    public ArticlePricePartnersResponse Get(ArticlePricePartners request)
    {
      ArticlePricePartnersResponse response = new ArticlePricePartnersResponse();
      List<Bm2s.Data.Common.BLL.Article.ArticlePricePartner> items = new List<Data.Common.BLL.Article.ArticlePricePartner>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.ArticlePricePartners.Where(item =>
          (request.PartnerId == 0 || item.PartnerId == request.PartnerId) &&
          (request.ArticleId == 0 || item.ArticleId == request.ArticleId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.ArticlePricePartners.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Article.ArticlePricePartner()
                        {
                          AddPrice = item.AddPrice,
                          Article = new ArticlesService().Get(new Articles() { Ids = new List<int>() { item.ArticleId } }).Articles.FirstOrDefault(),
                          EndingDate = item.EndingDate,
                          Id = item.Id,
                          Multiplier = item.Multiplier,
                          Partner = new PartnersService().Get(new Partners() { Ids = new List<int>() { item.PartnerId } }).Partners.FirstOrDefault(),
                          Price = item.Price,
                          StartingDate = item.StartingDate
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.ArticlePricePartners.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.ArticlePricePartners.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.ArticlePricePartners.Count + (collection.Count() % response.ArticlePricePartners.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public ArticlePricePartnersResponse Post(ArticlePricePartners request)
    {
      if (request.ArticlePriceParner.Id > 0)
      {
        Bm2s.Data.Common.BLL.Article.ArticlePricePartner item = Datas.Instance.DataStorage.ArticlePricePartners[request.ArticlePriceParner.Id];
        item.AddPrice = request.ArticlePriceParner.AddPrice;
        item.ArticleId = request.ArticlePriceParner.Article.Id;
        item.EndingDate = request.ArticlePriceParner.EndingDate;
        item.Multiplier = request.ArticlePriceParner.Multiplier;
        item.PartnerId = request.ArticlePriceParner.Partner.Id;
        item.Price = request.ArticlePriceParner.Price;
        item.StartingDate = request.ArticlePriceParner.StartingDate;
        Datas.Instance.DataStorage.ArticlePricePartners[request.ArticlePriceParner.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Article.ArticlePricePartner item = new Data.Common.BLL.Article.ArticlePricePartner()
        {
          AddPrice = request.ArticlePriceParner.AddPrice,
          ArticleId = request.ArticlePriceParner.Article.Id,
          EndingDate = request.ArticlePriceParner.EndingDate,
          Multiplier = request.ArticlePriceParner.Multiplier,
          PartnerId = request.ArticlePriceParner.Partner.Id,
          Price = request.ArticlePriceParner.Price,
          StartingDate = request.ArticlePriceParner.StartingDate
        };

        Datas.Instance.DataStorage.ArticlePricePartners.Add(item);
        request.ArticlePriceParner.Id = item.Id;
      }

      ArticlePricePartnersResponse response = new ArticlePricePartnersResponse();
      response.ArticlePricePartners.Add(request.ArticlePriceParner);
      return response;
    }

    public bool Delete(ArticlePricePartners request)
    {
      bool result = true;
      Bm2s.Data.Common.BLL.Article.ArticlePricePartner item = Datas.Instance.DataStorage.ArticlePricePartners.FirstOrDefault(nomenclature => nomenclature.Id == request.ArticlePriceParner.Id);
      if (item != null)
      {
        result = Datas.Instance.DataStorage.ArticlePricePartners.Remove(item);
      }

      return result;
    }
  }
}
