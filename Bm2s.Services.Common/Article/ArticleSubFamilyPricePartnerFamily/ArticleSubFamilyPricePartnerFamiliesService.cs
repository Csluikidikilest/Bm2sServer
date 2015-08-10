using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.Article.ArticleSubFamilyPricePartnerFamily
{
  public class ArticleSubFamilyPricePartnerFamiliesService : Service
  {
    public object Get(ArticleSubFamilyPricePartnerFamilies request)
    {
      ArticleSubFamilyPricePartnerFamiliesResponse response = new ArticleSubFamilyPricePartnerFamiliesResponse();

      if (!request.Ids.Any())
      {
        response.ArticleSubFamilyPricePartnerFamilies.AddRange(Datas.Instance.DataStorage.ArticleSubFamilyPricePartnerFamilies.Where(item =>
          (request.PartnerFamilyId == 0 || item.PartnerFamilyId == request.PartnerFamilyId) &&
          (request.ArticleSubFamilyId == 0 || item.ArticleSubFamilyId == request.ArticleSubFamilyId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
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
