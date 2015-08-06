using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Parameter.ArticleSubFamilyPartnerVat
{
  public class ArticleSubFamilyPartnerVatsService : Service
  {
    public object Get(ArticleSubFamilyPartnerVats request)
    {
      ArticleSubFamilyPartnerVatsResponse response = new ArticleSubFamilyPartnerVatsResponse();

      if (!request.Ids.Any())
      {
        response.ArticleSubFamilyPartnerVats.AddRange(Datas.Instance.DataStorage.ArticleSubFamilyPartnerVats.Where(item =>
          (request.ArticleSubFamilyId == 0 || item.ArticleSubFamilyId == request.ArticleSubFamilyId) &&
          (request.PartnerId == 0 || item.PartnerId == request.PartnerId) &&
          (request.VatId == 0 || item.VatId == request.VatId)
          ));
      }
      else
      {
        response.ArticleSubFamilyPartnerVats.AddRange(Datas.Instance.DataStorage.ArticleSubFamilyPartnerVats.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(ArticleSubFamilyPartnerVats request)
    {
      if (request.ArticleSubFamilyPartnerVat.Id > 0)
      {
        Datas.Instance.DataStorage.ArticleSubFamilyPartnerVats[request.ArticleSubFamilyPartnerVat.Id] = request.ArticleSubFamilyPartnerVat;
      }
      else
      {
        Datas.Instance.DataStorage.ArticleSubFamilyPartnerVats.Add(request.ArticleSubFamilyPartnerVat);
      }
      return request.ArticleSubFamilyPartnerVat;
    }
  }
}
