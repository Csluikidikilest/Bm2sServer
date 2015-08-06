using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Parameter.ArticleFamilyPartnerVat
{
  public class ArticleFamilyPartnerVatsService : Service
  {
    public object Get(ArticleFamilyPartnerVats request)
    {
      ArticleFamilyPartnerVatsResponse response = new ArticleFamilyPartnerVatsResponse();

      if (!request.Ids.Any())
      {
        response.ArticleFamilyPartnerVats.AddRange(Datas.Instance.DataStorage.ArticleFamilyPartnerVats.Where(item =>
          (request.ArticleFamilyId == 0 || item.ArticleFamilyId == request.ArticleFamilyId) &&
          (request.PartnerId == 0 || item.PartnerId == request.PartnerId) &&
          (request.VatId == 0 || item.VatId == request.VatId)
          ));
      }
      else
      {
        response.ArticleFamilyPartnerVats.AddRange(Datas.Instance.DataStorage.ArticleFamilyPartnerVats.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(ArticleFamilyPartnerVats request)
    {
      if (request.ArticleFamilyPartnerVat.Id > 0)
      {
        Datas.Instance.DataStorage.ArticleFamilyPartnerVats[request.ArticleFamilyPartnerVat.Id] = request.ArticleFamilyPartnerVat;
      }
      else
      {
        Datas.Instance.DataStorage.ArticleFamilyPartnerVats.Add(request.ArticleFamilyPartnerVat);
      }
      return request.ArticleFamilyPartnerVat;
    }
  }
}
