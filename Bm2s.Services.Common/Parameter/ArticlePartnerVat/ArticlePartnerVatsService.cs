using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Article.Article;
using Bm2s.Response.Common.Parameter.ArticlePartnerVat;
using Bm2s.Response.Common.Parameter.Vat;
using Bm2s.Response.Common.Partner.Partner;
using Bm2s.Services.Common.Article.Article;
using Bm2s.Services.Common.Parameter.Vat;
using Bm2s.Services.Common.Partner.Partner;
using ServiceStack.ServiceInterface;
using System;

namespace Bm2s.Services.Common.Parameter.ArticlePartnerVat
{
  public class ArticlePartnerVatsService : Service
  {
    public ArticlePartnerVatsResponse Get(ArticlePartnerVats request)
    {
      ArticlePartnerVatsResponse response = new ArticlePartnerVatsResponse();
      List<Bm2s.Data.Common.BLL.Parameter.Arpv> items = new List<Data.Common.BLL.Parameter.Arpv>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.ArticlePartnerVats.Where(item =>
          (request.ArticleId == 0 || item.ArtiId == request.ArticleId) &&
          (request.PartnerId == 0 || item.PartId == request.PartnerId) &&
          (request.VatId == 0 || item.VatId == request.VatId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.ArticlePartnerVats.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Parameter.ArticlePartnerVat()
                        {
                          AccountingEntry = item.AccountingEntry,
                          Article = new ArticlesService().Get(new Articles() { Ids = new List<int>() { item.ArtiId } }).Articles.FirstOrDefault(),
                          Id = item.Id,
                          Multiplier = Convert.ToDecimal(item.Multiplier),
                          Partner = new PartnersService().Get(new Partners() { Ids = new List<int>() { item.PartId } }).Partners.FirstOrDefault(),
                          Rate = Convert.ToDecimal(item.Rate),
                          Vat = new VatsService().Get(new Vats() { Ids = new List<int>() { item.VatId } }).Vats.FirstOrDefault()
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.ArticlePartnerVats.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.ArticlePartnerVats.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.ArticlePartnerVats.Count + (collection.Count() % response.ArticlePartnerVats.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public ArticlePartnerVatsResponse Post(ArticlePartnerVats request)
    {
      if (request.ArticlePartnerVat.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.Arpv item = Datas.Instance.DataStorage.ArticlePartnerVats[request.ArticlePartnerVat.Id];
        item.AccountingEntry = request.ArticlePartnerVat.AccountingEntry;
        item.ArtiId = request.ArticlePartnerVat.Article.Id;
        item.Multiplier = Convert.ToDouble(request.ArticlePartnerVat.Multiplier);
        item.PartId = request.ArticlePartnerVat.Partner.Id;
        item.Rate = Convert.ToDouble(request.ArticlePartnerVat.Rate);
        item.VatId = request.ArticlePartnerVat.Vat.Id;
        Datas.Instance.DataStorage.ArticlePartnerVats[request.ArticlePartnerVat.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.Arpv item = new Data.Common.BLL.Parameter.Arpv()
        {
          AccountingEntry = request.ArticlePartnerVat.AccountingEntry,
          ArtiId = request.ArticlePartnerVat.Article.Id,
          Multiplier = Convert.ToDouble(request.ArticlePartnerVat.Multiplier),
          PartId = request.ArticlePartnerVat.Partner.Id,
          Rate = Convert.ToDouble(request.ArticlePartnerVat.Rate),
          VatId = request.ArticlePartnerVat.Vat.Id
        };

        Datas.Instance.DataStorage.ArticlePartnerVats.Add(item);
        request.ArticlePartnerVat.Id = item.Id;
      }

      ArticlePartnerVatsResponse response = new ArticlePartnerVatsResponse();
      response.ArticlePartnerVats.Add(request.ArticlePartnerVat);
      return response;
    }

    public ArticlePartnerVatsResponse Delete(ArticlePartnerVats request)
    {
      Bm2s.Data.Common.BLL.Parameter.Arpv item = Datas.Instance.DataStorage.ArticlePartnerVats[request.ArticlePartnerVat.Id];
      Datas.Instance.DataStorage.ArticlePartnerVats.Remove(item);

      ArticlePartnerVatsResponse response = new ArticlePartnerVatsResponse();
      response.ArticlePartnerVats.Add(request.ArticlePartnerVat);
      return response;
    }
  }
}
