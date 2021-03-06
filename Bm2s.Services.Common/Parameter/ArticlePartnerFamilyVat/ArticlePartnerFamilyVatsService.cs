﻿using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Article.Article;
using Bm2s.Response.Common.Parameter.ArticlePartnerFamilyVat;
using Bm2s.Response.Common.Parameter.Vat;
using Bm2s.Response.Common.Partner.PartnerFamily;
using Bm2s.Services.Common.Article.Article;
using Bm2s.Services.Common.Parameter.Vat;
using Bm2s.Services.Common.Partner.PartnerFamily;
using ServiceStack.ServiceInterface;
using System;

namespace Bm2s.Services.Common.Parameter.ArticlePartnerFamilyVat
{
  class ArticlePartnerFamilyVatsService : Service
  {
    public ArticlePartnerFamilyVatsResponse Get(ArticlePartnerFamilyVats request)
    {
      ArticlePartnerFamilyVatsResponse response = new ArticlePartnerFamilyVatsResponse();
      List<Bm2s.Data.Common.BLL.Parameter.ArticlePartnerFamilyVat> items = new List<Data.Common.BLL.Parameter.ArticlePartnerFamilyVat>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.ArticlePartnerFamilyVats.Where(item =>
          (request.ArticleId == 0 || item.ArticleId == request.ArticleId) &&
          (request.PartnerFamilyId == 0 || item.PartnerFamilyId == request.PartnerFamilyId) &&
          (request.VatId == 0 || item.VatId == request.VatId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.ArticlePartnerFamilyVats.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Parameter.ArticlePartnerFamilyVat()
                        {
                          AccountingEntry = item.AccountingEntry,
                          Article = new ArticlesService().Get(new Articles() { Ids = new List<int>() { item.ArticleId } }).Articles.FirstOrDefault(),
                          Id = item.Id,
                          Multiplier = Convert.ToDecimal(item.Multiplier),
                          PartnerFamily = new PartnerFamiliesService().Get(new PartnerFamilies() { Ids = new List<int>() { item.PartnerFamilyId } }).PartnerFamilies.FirstOrDefault(),
                          Rate = Convert.ToDecimal(item.Rate),
                          Vat = new VatsService().Get(new Vats() { Ids = new List<int>() { item.VatId } }).Vats.FirstOrDefault()
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.ArticlePartnerFamilyVats.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.ArticlePartnerFamilyVats.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.ArticlePartnerFamilyVats.Count + (collection.Count() % response.ArticlePartnerFamilyVats.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public ArticlePartnerFamilyVatsResponse Post(ArticlePartnerFamilyVats request)
    {
      if (request.ArticlePartnerFamilyVat.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.ArticlePartnerFamilyVat item = Datas.Instance.DataStorage.ArticlePartnerFamilyVats[request.ArticlePartnerFamilyVat.Id];
        item.AccountingEntry = request.ArticlePartnerFamilyVat.AccountingEntry;
        item.ArticleId = request.ArticlePartnerFamilyVat.Article.Id;
        item.Multiplier = Convert.ToDouble(request.ArticlePartnerFamilyVat.Multiplier);
        item.PartnerFamilyId = request.ArticlePartnerFamilyVat.PartnerFamily.Id;
        item.Rate = Convert.ToDouble(request.ArticlePartnerFamilyVat.Rate);
        item.VatId = request.ArticlePartnerFamilyVat.Vat.Id;
        Datas.Instance.DataStorage.ArticlePartnerFamilyVats[request.ArticlePartnerFamilyVat.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.ArticlePartnerFamilyVat item = new Data.Common.BLL.Parameter.ArticlePartnerFamilyVat()
        {
          AccountingEntry = request.ArticlePartnerFamilyVat.AccountingEntry,
          ArticleId = request.ArticlePartnerFamilyVat.Article.Id,
          Multiplier = Convert.ToDouble(request.ArticlePartnerFamilyVat.Multiplier),
          PartnerFamilyId = request.ArticlePartnerFamilyVat.PartnerFamily.Id,
          Rate = Convert.ToDouble(request.ArticlePartnerFamilyVat.Rate),
          VatId = request.ArticlePartnerFamilyVat.Vat.Id
        };

        Datas.Instance.DataStorage.ArticlePartnerFamilyVats.Add(item);
        request.ArticlePartnerFamilyVat.Id = item.Id;
      }

      ArticlePartnerFamilyVatsResponse response = new ArticlePartnerFamilyVatsResponse();
      response.ArticlePartnerFamilyVats.Add(request.ArticlePartnerFamilyVat);
      return response;
    }

    public ArticlePartnerFamilyVatsResponse Delete(ArticlePartnerFamilyVats request)
    {
      Bm2s.Data.Common.BLL.Parameter.ArticlePartnerFamilyVat item = Datas.Instance.DataStorage.ArticlePartnerFamilyVats[request.ArticlePartnerFamilyVat.Id];
      Datas.Instance.DataStorage.ArticlePartnerFamilyVats.Remove(item);

      ArticlePartnerFamilyVatsResponse response = new ArticlePartnerFamilyVatsResponse();
      response.ArticlePartnerFamilyVats.Add(request.ArticlePartnerFamilyVat);
      return response;
    }
  }
}
