using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Parameter.ArticleFamilyPartnerFamilyVat
{
  class ArticleFamilyPartnerFamilyVatsService : Service
  {
    public object Get(ArticleFamilyPartnerFamilyVats request)
    {
      ArticleFamilyPartnerFamilyVatsResponse response = new ArticleFamilyPartnerFamilyVatsResponse();

      if (!request.Ids.Any())
      {
        response.ArticleFamilyPartnerFamilyVats.AddRange(Datas.Instance.DataStorage.ArticleFamilyPartnerFamilyVats.Where(item =>
          (request.ArticleFamilyId == 0 || item.ArticleFamilyId == request.ArticleFamilyId) &&
          (request.PartnerFamilyId == 0 || item.PartnerFamilyId == request.PartnerFamilyId) &&
          (request.VatId == 0 || item.VatId == request.VatId)
          ));
      }
      else
      {
        response.ArticleFamilyPartnerFamilyVats.AddRange(Datas.Instance.DataStorage.ArticleFamilyPartnerFamilyVats.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(ArticleFamilyPartnerFamilyVats request)
    {
      if (request.ArticleFamilyPartnerFamilyVat.Id > 0)
      {
        Datas.Instance.DataStorage.ArticleFamilyPartnerFamilyVats[request.ArticleFamilyPartnerFamilyVat.Id] = request.ArticleFamilyPartnerFamilyVat;
      }
      else
      {
        Datas.Instance.DataStorage.ArticleFamilyPartnerFamilyVats.Add(request.ArticleFamilyPartnerFamilyVat);
      }
      return request.ArticleFamilyPartnerFamilyVat;
    }
  }
}
