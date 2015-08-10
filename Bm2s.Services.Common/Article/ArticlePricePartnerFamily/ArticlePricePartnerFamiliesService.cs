using Bm2s.Data.Common.Utils;
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
    public object Get(ArticlePricePartnerFamilies request)
    {
      ArticlePricePartnerFamiliesResponse response = new ArticlePricePartnerFamiliesResponse();

      if (!request.Ids.Any())
      {
        response.ArticlePricePartnerFamilies.AddRange(Datas.Instance.DataStorage.ArticlePricePartnerFamilies.Where(item =>
          (request.PartnerFamilyId == 0 || item.PartnerFamilyId == request.PartnerFamilyId) &&
          (request.ArticleId == 0 || item.ArticleId == request.ArticleId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
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
