﻿using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Article.ArticleFamily;
using Bm2s.Response.Common.Parameter.ArticleFamilyPartnerVat;
using Bm2s.Response.Common.Parameter.Vat;
using Bm2s.Response.Common.Partner.Partner;
using Bm2s.Services.Common.Article.ArticleFamily;
using Bm2s.Services.Common.Parameter.Vat;
using Bm2s.Services.Common.Partner.Partner;
using ServiceStack.ServiceInterface;
using System;

namespace Bm2s.Services.Common.Parameter.ArticleFamilyPartnerVat
{
  public class ArticleFamilyPartnerVatsService : Service
  {
    public ArticleFamilyPartnerVatsResponse Get(ArticleFamilyPartnerVats request)
    {
      ArticleFamilyPartnerVatsResponse response = new ArticleFamilyPartnerVatsResponse();
      List<Bm2s.Data.Common.BLL.Parameter.ArticleFamilyPartnerVat> items = new List<Data.Common.BLL.Parameter.ArticleFamilyPartnerVat>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleFamilyPartnerVats.Where(item =>
          (request.ArticleFamilyId == 0 || item.ArticleFamilyId == request.ArticleFamilyId) &&
          (request.PartnerId == 0 || item.PartnerId == request.PartnerId) &&
          (request.VatId == 0 || item.VatId == request.VatId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleFamilyPartnerVats.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Parameter.ArticleFamilyPartnerVat()
                        {
                          AccountingEntry = item.AccountingEntry,
                          ArticleFamily = new ArticleFamiliesService().Get(new ArticleFamilies() { Ids = new List<int>() { item.ArticleFamilyId } }).ArticleFamilies.FirstOrDefault(),
                          Id = item.Id,
                          Multiplier = Convert.ToDecimal(item.Multiplier),
                          Partner = new PartnersService().Get(new Partners() { Ids = new List<int>() { item.PartnerId } }).Partners.FirstOrDefault(),
                          Rate = Convert.ToDecimal(item.Rate),
                          Vat = new VatsService().Get(new Vats() { Ids = new List<int>() { item.VatId } }).Vats.FirstOrDefault()
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.ArticleFamilyPartnerVats.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.ArticleFamilyPartnerVats.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.ArticleFamilyPartnerVats.Count + (collection.Count() % response.ArticleFamilyPartnerVats.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public ArticleFamilyPartnerVatsResponse Post(ArticleFamilyPartnerVats request)
    {
      if (request.ArticleFamilyPartnerVat.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.ArticleFamilyPartnerVat item = Datas.Instance.DataStorage.ArticleFamilyPartnerVats[request.ArticleFamilyPartnerVat.Id];
        item.AccountingEntry = request.ArticleFamilyPartnerVat.AccountingEntry;
        item.ArticleFamilyId = request.ArticleFamilyPartnerVat.ArticleFamily.Id;
        item.Multiplier = Convert.ToDouble(request.ArticleFamilyPartnerVat.Multiplier);
        item.PartnerId = request.ArticleFamilyPartnerVat.Partner.Id;
        item.Rate = Convert.ToDouble(request.ArticleFamilyPartnerVat.Rate);
        item.VatId = request.ArticleFamilyPartnerVat.Vat.Id;
        Datas.Instance.DataStorage.ArticleFamilyPartnerVats[request.ArticleFamilyPartnerVat.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.ArticleFamilyPartnerVat item = new Data.Common.BLL.Parameter.ArticleFamilyPartnerVat()
        {
          AccountingEntry = request.ArticleFamilyPartnerVat.AccountingEntry,
          ArticleFamilyId = request.ArticleFamilyPartnerVat.ArticleFamily.Id,
          Multiplier = Convert.ToDouble(request.ArticleFamilyPartnerVat.Multiplier),
          PartnerId = request.ArticleFamilyPartnerVat.Partner.Id,
          Rate = Convert.ToDouble(request.ArticleFamilyPartnerVat.Rate),
          VatId = request.ArticleFamilyPartnerVat.Vat.Id
        };

        Datas.Instance.DataStorage.ArticleFamilyPartnerVats.Add(item);
        request.ArticleFamilyPartnerVat.Id = item.Id;
      }

      ArticleFamilyPartnerVatsResponse response = new ArticleFamilyPartnerVatsResponse();
      response.ArticleFamilyPartnerVats.Add(request.ArticleFamilyPartnerVat);
      return response;
    }

    public ArticleFamilyPartnerVatsResponse Delete(ArticleFamilyPartnerVats request)
    {
      Bm2s.Data.Common.BLL.Parameter.ArticleFamilyPartnerVat item = Datas.Instance.DataStorage.ArticleFamilyPartnerVats[request.ArticleFamilyPartnerVat.Id];
      Datas.Instance.DataStorage.ArticleFamilyPartnerVats.Remove(item);

      ArticleFamilyPartnerVatsResponse response = new ArticleFamilyPartnerVatsResponse();
      response.ArticleFamilyPartnerVats.Add(request.ArticleFamilyPartnerVat);
      return response;
    }
  }
}
