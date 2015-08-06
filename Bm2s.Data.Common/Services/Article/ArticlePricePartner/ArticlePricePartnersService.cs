﻿using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Article.ArticlePriceParner
{
  public class ArticlePricePartnersService : Service
  {
    public object Get(ArticlePricePartners request)
    {
      ArticlePricePartnersResponse response = new ArticlePricePartnersResponse();

      if (!request.Ids.Any())
      {
        response.ArticlePricePartners.AddRange(Datas.Instance.DataStorage.ArticlePricePartners.Where(item =>
          (request.PartnerId == 0 || item.PartnerId == request.PartnerId) &&
          (request.ArticleId == 0 || item.ArticleId == request.ArticleId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        response.ArticlePricePartners.AddRange(Datas.Instance.DataStorage.ArticlePricePartners.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(ArticlePricePartners request)
    {
      if (request.ArticlePriceParner.Id > 0)
      {
        Datas.Instance.DataStorage.ArticlePricePartners[request.ArticlePriceParner.Id] = request.ArticlePriceParner;
      }
      else
      {
        Datas.Instance.DataStorage.ArticlePricePartners.Add(request.ArticlePriceParner);
      }
      return request.ArticlePriceParner;
    }
  }
}
