﻿using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.Article.ArticleSubFamilyPricePartner
{
  public class ArticleSubFamilyPricePartnersService : Service
  {
    public object Get(ArticleSubFamilyPricePartners request)
    {
      ArticleSubFamilyPricePartnersResponse response = new ArticleSubFamilyPricePartnersResponse();

      if (!request.Ids.Any())
      {
        response.ArticleSubFamilyPricePartners.AddRange(Datas.Instance.DataStorage.ArticleSubFamilyPricePartners.Where(item =>
          (request.PartnerId == 0 || item.PartnerId == request.PartnerId) &&
          (request.ArticleSubFamilyId == 0 || item.ArticleSubFamilyId == request.ArticleSubFamilyId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        response.ArticleSubFamilyPricePartners.AddRange(Datas.Instance.DataStorage.ArticleSubFamilyPricePartners.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(ArticleSubFamilyPricePartners request)
    {
      if (request.ArticleSubFamilyPricePartner.Id > 0)
      {
        Datas.Instance.DataStorage.ArticleSubFamilyPricePartners[request.ArticleSubFamilyPricePartner.Id] = request.ArticleSubFamilyPricePartner;
      }
      else
      {
        Datas.Instance.DataStorage.ArticleSubFamilyPricePartners.Add(request.ArticleSubFamilyPricePartner);
      }
      return request.ArticleSubFamilyPricePartner;
    }
  }
}
