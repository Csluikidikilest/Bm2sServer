﻿using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Parameter.ArticleSubFamilyPartnerFamilyVat
{
  public class ArticleSubFamilyPartnerFamilyVatsService : Service
  {
    public object Get(ArticleSubFamilyPartnerFamilyVats request)
    {
      ArticleSubFamilyPartnerFamilyVatsResponse response = new ArticleSubFamilyPartnerFamilyVatsResponse();

      if (!request.Ids.Any())
      {
        response.ArticleSubFamilyPartnerFamilyVats.AddRange(Datas.Instance.DataStorage.ArticleSubFamilyPartnerFamilyVats);
      }
      else
      {
        response.ArticleSubFamilyPartnerFamilyVats.AddRange(Datas.Instance.DataStorage.ArticleSubFamilyPartnerFamilyVats.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(ArticleSubFamilyPartnerFamilyVats request)
    {
      if (request.ArticleSubFamilyPartnerFamilyVat.Id > 0)
      {
        Datas.Instance.DataStorage.ArticleSubFamilyPartnerFamilyVats[request.ArticleSubFamilyPartnerFamilyVat.Id] = request.ArticleSubFamilyPartnerFamilyVat;
      }
      else
      {
        Datas.Instance.DataStorage.ArticleSubFamilyPartnerFamilyVats.Add(request.ArticleSubFamilyPartnerFamilyVat);
      }
      return request.ArticleSubFamilyPartnerFamilyVat;
    }
  }
}
