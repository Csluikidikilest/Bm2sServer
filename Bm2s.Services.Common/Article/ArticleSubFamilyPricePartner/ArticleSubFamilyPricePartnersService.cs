using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Services.Common.Article.ArticleSubFamily;
using Bm2s.Services.Common.Partner.Partner;
using Bm2s.Response.Common.Article.ArticleSubFamilyPricePartner;
using Bm2s.Response.Common.Article.ArticleSubFamily;
using Bm2s.Response.Common.Partner.Partner;

namespace Bm2s.Services.Common.Article.ArticleSubFamilyPricePartner
{
  public class ArticleSubFamilyPricePartnersService : Service
  {
    public ArticleSubFamilyPricePartnersResponse Get(ArticleSubFamilyPricePartners request)
    {
      ArticleSubFamilyPricePartnersResponse response = new ArticleSubFamilyPricePartnersResponse();
      List<Bm2s.Data.Common.BLL.Article.ArticleSubFamilyPricePartner> items = new List<Data.Common.BLL.Article.ArticleSubFamilyPricePartner>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleSubFamilyPricePartners.Where(item =>
          (request.PartnerId == 0 || item.PartnerId == request.PartnerId) &&
          (request.ArticleSubFamilyId == 0 || item.ArticleSubFamilyId == request.ArticleSubFamilyId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleSubFamilyPricePartners.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Article.ArticleSubFamilyPricePartner()
                        {
                          AddPrice = item.AddPrice,
                          ArticleSubFamily = new ArticleSubFamiliesService().Get(new ArticleSubFamilies() { Ids = new List<int>() { item.ArticleSubFamilyId } }).ArticleSubFamilies.FirstOrDefault(),
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
        response.ArticleSubFamilyPricePartners.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.ArticleSubFamilyPricePartners.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.ArticleSubFamilyPricePartners.Count + (collection.Count() % response.ArticleSubFamilyPricePartners.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public ArticleSubFamilyPricePartnersResponse Post(ArticleSubFamilyPricePartners request)
    {
      if (request.ArticleSubFamilyPricePartner.Id > 0)
      {
        Bm2s.Data.Common.BLL.Article.ArticleSubFamilyPricePartner item = Datas.Instance.DataStorage.ArticleSubFamilyPricePartners[request.ArticleSubFamilyPricePartner.Id];
        item.AddPrice = request.ArticleSubFamilyPricePartner.AddPrice;
        item.ArticleSubFamilyId = request.ArticleSubFamilyPricePartner.ArticleSubFamily.Id;
        item.EndingDate = request.ArticleSubFamilyPricePartner.EndingDate;
        item.Multiplier = request.ArticleSubFamilyPricePartner.Multiplier;
        item.PartnerId = request.ArticleSubFamilyPricePartner.Partner.Id;
        item.Price = request.ArticleSubFamilyPricePartner.Price;
        item.StartingDate = request.ArticleSubFamilyPricePartner.StartingDate;
        Datas.Instance.DataStorage.ArticleSubFamilyPricePartners[request.ArticleSubFamilyPricePartner.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Article.ArticleSubFamilyPricePartner item = new Data.Common.BLL.Article.ArticleSubFamilyPricePartner()
        {
          AddPrice = request.ArticleSubFamilyPricePartner.AddPrice,
          ArticleSubFamilyId = request.ArticleSubFamilyPricePartner.ArticleSubFamily.Id,
          EndingDate = request.ArticleSubFamilyPricePartner.EndingDate,
          Multiplier = request.ArticleSubFamilyPricePartner.Multiplier,
          PartnerId = request.ArticleSubFamilyPricePartner.Partner.Id,
          Price = request.ArticleSubFamilyPricePartner.Price,
          StartingDate = request.ArticleSubFamilyPricePartner.StartingDate
        };

        Datas.Instance.DataStorage.ArticleSubFamilyPricePartners.Add(item);
        request.ArticleSubFamilyPricePartner.Id = item.Id;
      }

      ArticleSubFamilyPricePartnersResponse response = new ArticleSubFamilyPricePartnersResponse();
      response.ArticleSubFamilyPricePartners.Add(request.ArticleSubFamilyPricePartner);
      return response;
    }

    public ArticleSubFamilyPricePartnersResponse Delete(ArticleSubFamilyPricePartners request)
    {
      Bm2s.Data.Common.BLL.Article.ArticleSubFamilyPricePartner item = Datas.Instance.DataStorage.ArticleSubFamilyPricePartners.FirstOrDefault(nomenclature => nomenclature.Id == request.ArticleSubFamilyPricePartner.Id);
      if (item != null)
      {
        Datas.Instance.DataStorage.ArticleSubFamilyPricePartners.Remove(item);
      }

      ArticleSubFamilyPricePartnersResponse response = new ArticleSubFamilyPricePartnersResponse();
      response.ArticleSubFamilyPricePartners.Add(request.ArticleSubFamilyPricePartner);
      return response;
    }
  }
}
