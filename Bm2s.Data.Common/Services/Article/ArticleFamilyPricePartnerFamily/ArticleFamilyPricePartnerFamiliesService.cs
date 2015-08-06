using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Article.ArticleFamilyPricePartnerFamily
{
  public class ArticleFamilyPricePartnerFamiliesService : Service
  {
    public object Get(ArticleFamilyPricePartnerFamilies request)
    {
      ArticleFamilyPricePartnerFamiliesResponse response = new ArticleFamilyPricePartnerFamiliesResponse();

      if (!request.Ids.Any())
      {
        response.ArticleFamilyPricePartnerFamilies.AddRange(Datas.Instance.DataStorage.ArticleFamilyPricePartnerFamilies.Where(item =>
          (request.PartnerFamilyId == 0 || item.PartnerFamilyId == request.PartnerFamilyId) &&
          (request.ArticleFamilyId == 0 || item.ArticleFamilyId == request.ArticleFamilyId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        response.ArticleFamilyPricePartnerFamilies.AddRange(Datas.Instance.DataStorage.ArticleFamilyPricePartnerFamilies.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(ArticleFamilyPricePartnerFamilies request)
    {
      if (request.ArticleFamilyPricePartnerFamily.Id > 0)
      {
        Datas.Instance.DataStorage.ArticleFamilyPricePartnerFamilies[request.ArticleFamilyPricePartnerFamily.Id] = request.ArticleFamilyPricePartnerFamily;
      }
      else
      {
        Datas.Instance.DataStorage.ArticleFamilyPricePartnerFamilies.Add(request.ArticleFamilyPricePartnerFamily);
      }
      return request.ArticleFamilyPricePartnerFamily;
    }
  }
}
