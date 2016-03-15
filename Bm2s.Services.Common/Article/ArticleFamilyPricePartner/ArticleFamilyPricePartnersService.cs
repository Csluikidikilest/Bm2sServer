using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Services.Common.Article.ArticleFamily;
using Bm2s.Services.Common.Partner.Partner;
using Bm2s.Response.Common.Article.ArticleFamilyPricePartner;
using Bm2s.Response.Common.Article.ArticleFamily;
using Bm2s.Response.Common.Partner.Partner;

namespace Bm2s.Services.Common.Article.ArticleFamilyPricePartner
{
  public class ArticleFamilyPricePartnersService : Service
  {
    public ArticleFamilyPricePartnersResponse Get(ArticleFamilyPricePartners request)
    {
      ArticleFamilyPricePartnersResponse response = new ArticleFamilyPricePartnersResponse();
      List<Bm2s.Data.Common.BLL.Article.ArticleFamilyPricePartner> items = new List<Data.Common.BLL.Article.ArticleFamilyPricePartner>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleFamilyPricePartners.Where(item =>
          (request.PartnerId == 0 || item.PartnerId == request.PartnerId) &&
          (request.ArticleFamilyId == 0 || item.ArticleFamilyId == request.ArticleFamilyId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleFamilyPricePartners.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Article.ArticleFamilyPricePartner()
                        {
                          AddPrice = item.AddPrice,
                          ArticleFamily = new ArticleFamiliesService().Get(new ArticleFamilies() { Ids = new List<int>() { item.ArticleFamilyId } }).ArticleFamilies.FirstOrDefault(),
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
        response.ArticleFamilyPricePartners.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.ArticleFamilyPricePartners.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.ArticleFamilyPricePartners.Count + (collection.Count() % response.ArticleFamilyPricePartners.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public ArticleFamilyPricePartnersResponse Post(ArticleFamilyPricePartners request)
    {
      if (request.ArticleFamilyPricePartner.Id > 0)
      {
        Bm2s.Data.Common.BLL.Article.ArticleFamilyPricePartner item = Datas.Instance.DataStorage.ArticleFamilyPricePartners[request.ArticleFamilyPricePartner.Id];
        item.AddPrice = request.ArticleFamilyPricePartner.AddPrice;
        item.ArticleFamilyId = request.ArticleFamilyPricePartner.ArticleFamily.Id;
        item.EndingDate = request.ArticleFamilyPricePartner.EndingDate;
        item.Multiplier = request.ArticleFamilyPricePartner.Multiplier;
        item.PartnerId = request.ArticleFamilyPricePartner.Partner.Id;
        item.Price = request.ArticleFamilyPricePartner.Price;
        item.StartingDate = request.ArticleFamilyPricePartner.StartingDate;
        Datas.Instance.DataStorage.ArticleFamilyPricePartners[request.ArticleFamilyPricePartner.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Article.ArticleFamilyPricePartner item = new Data.Common.BLL.Article.ArticleFamilyPricePartner()
          {
            AddPrice = request.ArticleFamilyPricePartner.AddPrice,
            ArticleFamilyId = request.ArticleFamilyPricePartner.ArticleFamily.Id,
            EndingDate = request.ArticleFamilyPricePartner.EndingDate,
            Multiplier = request.ArticleFamilyPricePartner.Multiplier,
            PartnerId = request.ArticleFamilyPricePartner.Partner.Id,
            Price = request.ArticleFamilyPricePartner.Price,
            StartingDate = request.ArticleFamilyPricePartner.StartingDate
          };

        Datas.Instance.DataStorage.ArticleFamilyPricePartners.Add(item);
        request.ArticleFamilyPricePartner.Id = item.Id;
      }

      ArticleFamilyPricePartnersResponse response = new ArticleFamilyPricePartnersResponse();
      response.ArticleFamilyPricePartners.Add(request.ArticleFamilyPricePartner);
      return response;
    }

    public ArticleFamilyPricePartnersResponse Delete(ArticleFamilyPricePartners request)
    {
      Bm2s.Data.Common.BLL.Article.ArticleFamilyPricePartner item = Datas.Instance.DataStorage.ArticleFamilyPricePartners[request.ArticleFamilyPricePartner.Id];
      item.EndingDate = DateTime.Now;

      ArticleFamilyPricePartnersResponse response = new ArticleFamilyPricePartnersResponse();
      response.ArticleFamilyPricePartners.Add(request.ArticleFamilyPricePartner);
      return response;
    }
  }
}
