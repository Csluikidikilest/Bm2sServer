﻿using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System.Linq;
using System.Collections.Generic;
using Bm2s.Services.Common.Article.Article;
using Bm2s.Response.Common.Article.Nomenclature;
using Bm2s.Response.Common.Article.Article;

namespace Bm2s.Services.Common.Article.Nomenclature
{
  public class NomenclaturesService : Service
  {
    public NomenclaturesResponse Get(Nomenclatures request)
    {
      NomenclaturesResponse response = new NomenclaturesResponse();
      List<Bm2s.Data.Common.BLL.Article.Nomenclature> items = new List<Data.Common.BLL.Article.Nomenclature>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Nomenclatures.Where(item =>
          request.ArticleId == 0 || item.ArticleChildId == request.ArticleId || item.ArticleParentId == request.ArticleId
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Nomenclatures.Where(item => request.Ids.Contains(item.Id)));
      }

      response.Nomenclatures.AddRange((from item in items
                                      select new Bm2s.Poco.Common.Article.Nomenclature()
                                      {
                                        ArticleChild = new ArticlesService().Get(new Articles() { Ids = new List<int>() { item.ArticleChildId } }).Articles.FirstOrDefault(),
                                        ArticleParent = new ArticlesService().Get(new Articles() { Ids = new List<int>() { item.ArticleParentId } }).Articles.FirstOrDefault(),
                                        BuyPrice = item.BuyPrice,
                                        Id = item.Id,
                                        Multiplier = item.Multiplier,
                                        Quantity = item.Quantity
                                      }).AsQueryable().OrderBy(request.Order, request.AscendingOrder).Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));

      return response;
    }

    public NomenclaturesResponse Post(Nomenclatures request)
    {
      if (request.Nomenclature.Id > 0)
      {
        Bm2s.Data.Common.BLL.Article.Nomenclature item = Datas.Instance.DataStorage.Nomenclatures[request.Nomenclature.Id];
        item.ArticleChildId = request.Nomenclature.ArticleChild.Id;
        item.ArticleParentId = request.Nomenclature.ArticleParent.Id;
        item.BuyPrice = request.Nomenclature.BuyPrice;
        item.Multiplier = request.Nomenclature.Multiplier;
        item.Quantity = request.Nomenclature.Quantity;
        Datas.Instance.DataStorage.Nomenclatures[request.Nomenclature.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Article.Nomenclature item = new Data.Common.BLL.Article.Nomenclature()
        {
          ArticleChildId = request.Nomenclature.ArticleChild.Id,
          ArticleParentId = request.Nomenclature.ArticleParent.Id,
          BuyPrice = request.Nomenclature.BuyPrice,
          Multiplier = request.Nomenclature.Multiplier,
          Quantity = request.Nomenclature.Quantity
        };

        Datas.Instance.DataStorage.Nomenclatures.Add(item);
        request.Nomenclature.Id = item.Id;
      }

      NomenclaturesResponse response = new NomenclaturesResponse();
      response.Nomenclatures.Add(request.Nomenclature);
      return response;
    }
  }
}
