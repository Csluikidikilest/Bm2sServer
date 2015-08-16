﻿using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

      response.ArticlePricePartnerFamilies.AddRange(from item in items
                                                    select new Bm2s.Poco.Common.Article.ArticlePricePartnerFamily()
                                                    {
                                                      Article = null,
                                                      EndingDate = item.EndingDate,
                                                      Id = item.Id,
                                                      Multiplier = item.Multiplier,
                                                      PartnerFamily = null,
                                                      Price = item.Price,
                                                      StartingDate = item.StartingDate
                                                    });

      return response;
    }

    public Bm2s.Poco.Common.Article.ArticlePricePartnerFamily Post(ArticlePricePartnerFamilies request)
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

      return request.ArticlePricePartnerFamily;
    }
  }
}
