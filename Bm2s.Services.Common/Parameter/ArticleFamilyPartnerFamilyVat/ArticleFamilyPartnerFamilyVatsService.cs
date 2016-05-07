using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Article.ArticleFamily;
using Bm2s.Response.Common.Parameter.ArticleFamilyPartnerFamilyVat;
using Bm2s.Response.Common.Parameter.Vat;
using Bm2s.Response.Common.Partner.PartnerFamily;
using Bm2s.Services.Common.Article.ArticleFamily;
using Bm2s.Services.Common.Parameter.Vat;
using Bm2s.Services.Common.Partner.PartnerFamily;
using ServiceStack.ServiceInterface;
using System;

namespace Bm2s.Services.Common.Parameter.ArticleFamilyPartnerFamilyVat
{
  class ArticleFamilyPartnerFamilyVatsService : Service
  {
    public ArticleFamilyPartnerFamilyVatsResponse Get(ArticleFamilyPartnerFamilyVats request)
    {
      ArticleFamilyPartnerFamilyVatsResponse response = new ArticleFamilyPartnerFamilyVatsResponse();
      List<Bm2s.Data.Common.BLL.Parameter.ArticleFamilyPartnerFamilyVat> items = new List<Data.Common.BLL.Parameter.ArticleFamilyPartnerFamilyVat>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleFamilyPartnerFamilyVats.Where(item =>
          (request.ArticleFamilyId == 0 || item.ArticleFamilyId == request.ArticleFamilyId) &&
          (request.PartnerFamilyId == 0 || item.PartnerFamilyId == request.PartnerFamilyId) &&
          (request.VatId == 0 || item.VatId == request.VatId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleFamilyPartnerFamilyVats.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Parameter.ArticleFamilyPartnerFamilyVat()
                        {
                          AccountingEntry = item.AccountingEntry,
                          ArticleFamily = new ArticleFamiliesService().Get(new ArticleFamilies() { Ids = new List<int>() { item.ArticleFamilyId } }).ArticleFamilies.FirstOrDefault(),
                          Id = item.Id,
                          Multiplier = Convert.ToDecimal(item.Multiplier),
                          PartnerFamily = new PartnerFamiliesService().Get(new PartnerFamilies() { Ids = new List<int>() { item.PartnerFamilyId } }).PartnerFamilies.FirstOrDefault(),
                          Rate = Convert.ToDecimal(item.Rate),
                          Vat = new VatsService().Get(new Vats() { Ids = new List<int>() { item.VatId } }).Vats.FirstOrDefault()
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.ArticleFamilyPartnerFamilyVats.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.ArticleFamilyPartnerFamilyVats.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.ArticleFamilyPartnerFamilyVats.Count + (collection.Count() % response.ArticleFamilyPartnerFamilyVats.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public ArticleFamilyPartnerFamilyVatsResponse Post(ArticleFamilyPartnerFamilyVats request)
    {
      if (request.ArticleFamilyPartnerFamilyVat.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.ArticleFamilyPartnerFamilyVat item = Datas.Instance.DataStorage.ArticleFamilyPartnerFamilyVats[request.ArticleFamilyPartnerFamilyVat.Id];
        item.AccountingEntry = request.ArticleFamilyPartnerFamilyVat.AccountingEntry;
        item.ArticleFamilyId = request.ArticleFamilyPartnerFamilyVat.ArticleFamily.Id;
        item.Multiplier = Convert.ToDouble(request.ArticleFamilyPartnerFamilyVat.Multiplier);
        item.PartnerFamilyId = request.ArticleFamilyPartnerFamilyVat.PartnerFamily.Id;
        item.Rate = Convert.ToDouble(request.ArticleFamilyPartnerFamilyVat.Rate);
        item.VatId = request.ArticleFamilyPartnerFamilyVat.Vat.Id;
        Datas.Instance.DataStorage.ArticleFamilyPartnerFamilyVats[request.ArticleFamilyPartnerFamilyVat.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.ArticleFamilyPartnerFamilyVat item = new Data.Common.BLL.Parameter.ArticleFamilyPartnerFamilyVat()
        {
          AccountingEntry = request.ArticleFamilyPartnerFamilyVat.AccountingEntry,
          ArticleFamilyId = request.ArticleFamilyPartnerFamilyVat.ArticleFamily.Id,
          Multiplier = Convert.ToDouble(request.ArticleFamilyPartnerFamilyVat.Multiplier),
          PartnerFamilyId = request.ArticleFamilyPartnerFamilyVat.PartnerFamily.Id,
          Rate = Convert.ToDouble(request.ArticleFamilyPartnerFamilyVat.Rate),
          VatId = request.ArticleFamilyPartnerFamilyVat.Vat.Id,
        };

        Datas.Instance.DataStorage.ArticleFamilyPartnerFamilyVats.Add(item);
        request.ArticleFamilyPartnerFamilyVat.Id = item.Id;
      }

      ArticleFamilyPartnerFamilyVatsResponse response = new ArticleFamilyPartnerFamilyVatsResponse();
      response.ArticleFamilyPartnerFamilyVats.Add(request.ArticleFamilyPartnerFamilyVat);
      return response;
    }

    public ArticleFamilyPartnerFamilyVatsResponse Delete(ArticleFamilyPartnerFamilyVats request)
    {
      Bm2s.Data.Common.BLL.Parameter.ArticleFamilyPartnerFamilyVat item = Datas.Instance.DataStorage.ArticleFamilyPartnerFamilyVats[request.ArticleFamilyPartnerFamilyVat.Id];
      Datas.Instance.DataStorage.ArticleFamilyPartnerFamilyVats.Remove(item);

      ArticleFamilyPartnerFamilyVatsResponse response = new ArticleFamilyPartnerFamilyVatsResponse();
      response.ArticleFamilyPartnerFamilyVats.Add(request.ArticleFamilyPartnerFamilyVat);
      return response;
    }
  }
}
