using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Parameter.ArticlePartnerFamilyVat
{
  class ArticlePartnerFamilyVatsService : Service
  {
    public object Get(ArticlePartnerFamilyVats request)
    {
      ArticlePartnerFamilyVatsResponse response = new ArticlePartnerFamilyVatsResponse();

      if (!request.Ids.Any())
      {
        response.ArticlePartnerFamilyVats.AddRange(Datas.Instance.DataStorage.ArticlePartnerFamilyVats.Where(item =>
          (request.ArticleId == 0 || item.ArticleId == request.ArticleId) &&
          (request.PartnerFamilyId == 0 || item.PartnerFamilyId == request.PartnerFamilyId) &&
          (request.VatId == 0 || item.VatId == request.VatId)
          ));
      }
      else
      {
        response.ArticlePartnerFamilyVats.AddRange(Datas.Instance.DataStorage.ArticlePartnerFamilyVats.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(ArticlePartnerFamilyVats request)
    {
      if (request.ArticlePartnerFamilyVat.Id > 0)
      {
        Datas.Instance.DataStorage.ArticlePartnerFamilyVats[request.ArticlePartnerFamilyVat.Id] = request.ArticlePartnerFamilyVat;
      }
      else
      {
        Datas.Instance.DataStorage.ArticlePartnerFamilyVats.Add(request.ArticlePartnerFamilyVat);
      }
      return request.ArticlePartnerFamilyVat;
    }
  }
}
