using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Article.ArticlePricePartnerFamily
{
  public class ArticlePricePartnerFamiliesService : Service
  {
    public object Get(ArticlePricePartnerFamilies request)
    {
      ArticlePricePartnerFamiliesResponse response = new ArticlePricePartnerFamiliesResponse();

      if (!request.Ids.Any())
      {
        response.ArticlePricePartnerFamilies.AddRange(Datas.Instance.DataStorage.ArticlePricePartnerFamilies);
      }
      else
      {
        response.ArticlePricePartnerFamilies.AddRange(Datas.Instance.DataStorage.ArticlePricePartnerFamilies.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(ArticlePricePartnerFamilies request)
    {
      if (request.ArticlePricePartnerFamily.Id > 0)
      {
        Datas.Instance.DataStorage.ArticlePricePartnerFamilies[request.ArticlePricePartnerFamily.Id] = request.ArticlePricePartnerFamily;
      }
      else
      {
        Datas.Instance.DataStorage.ArticlePricePartnerFamilies.Add(request.ArticlePricePartnerFamily);
      }
      return request.ArticlePricePartnerFamily;
    }
  }
}
