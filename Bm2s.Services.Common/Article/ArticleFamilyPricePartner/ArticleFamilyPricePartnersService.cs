using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.Article.ArticleFamilyPricePartner
{
  public class ArticleFamilyPricePartnersService : Service
  {
    public object Get(ArticleFamilyPricePartners request)
    {
      ArticleFamilyPricePartnersResponse response = new ArticleFamilyPricePartnersResponse();

      if (!request.Ids.Any())
      {
        response.ArticleFamilyPricePartners.AddRange(Datas.Instance.DataStorage.ArticleFamilyPricePartners.Where(item =>
          (request.PartnerId == 0 || item.PartnerId == request.PartnerId) &&
          (request.ArticleFamilyId == 0 || item.ArticleFamilyId == request.ArticleFamilyId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        response.ArticleFamilyPricePartners.AddRange(Datas.Instance.DataStorage.ArticleFamilyPricePartners.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(ArticleFamilyPricePartners request)
    {
      if (request.ArticleFamilyPricePartner.Id > 0)
      {
        Datas.Instance.DataStorage.ArticleFamilyPricePartners[request.ArticleFamilyPricePartner.Id] = request.ArticleFamilyPricePartner;
      }
      else
      {
        Datas.Instance.DataStorage.ArticleFamilyPricePartners.Add(request.ArticleFamilyPricePartner);
      }
      return request.ArticleFamilyPricePartner;
    }
  }
}
