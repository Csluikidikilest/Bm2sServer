using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Article.ArticleSubFamilyPricePartnerFamily
{
  public class ArticleSubFamilyPricePartnerFamiliesService : Service
  {
    public object Get(ArticleSubFamilyPricePartnerFamilies request)
    {
      ArticleSubFamilyPricePartnerFamiliesResponse response = new ArticleSubFamilyPricePartnerFamiliesResponse();

      if (!request.Ids.Any())
      {
        response.ArticleSubFamilyPricePartnerFamilies.AddRange(Datas.Instance.DataStorage.ArticleSubFamilyPricePartnerFamilies);
      }
      else
      {
        response.ArticleSubFamilyPricePartnerFamilies.AddRange(Datas.Instance.DataStorage.ArticleSubFamilyPricePartnerFamilies.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(ArticleSubFamilyPricePartnerFamilies request)
    {
      if (request.ArticleSubFamilyPricePartnerFamily.Id > 0)
      {
        Datas.Instance.DataStorage.ArticleSubFamilyPricePartnerFamilies[request.ArticleSubFamilyPricePartnerFamily.Id] = request.ArticleSubFamilyPricePartnerFamily;
      }
      else
      {
        Datas.Instance.DataStorage.ArticleSubFamilyPricePartnerFamilies.Add(request.ArticleSubFamilyPricePartnerFamily);
      }
      return request.ArticleSubFamilyPricePartnerFamily;
    }
  }
}
