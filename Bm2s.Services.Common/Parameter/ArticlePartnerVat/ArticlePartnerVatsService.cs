using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.ArticlePartnerVat
{
  public class ArticlePartnerVatsService : Service
  {
    public object Get(ArticlePartnerVats request)
    {
      ArticlePartnerVatsResponse response = new ArticlePartnerVatsResponse();

      if (!request.Ids.Any())
      {
        response.ArticlePartnerVats.AddRange(Datas.Instance.DataStorage.ArticlePartnerVats.Where(item =>
          (request.ArticleId == 0 || item.ArticleId == request.ArticleId) &&
          (request.PartnerId == 0 || item.PartnerId == request.PartnerId) &&
          (request.VatId == 0 || item.VatId == request.VatId)
          ));
      }
      else
      {
        response.ArticlePartnerVats.AddRange(Datas.Instance.DataStorage.ArticlePartnerVats.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(ArticlePartnerVats request)
    {
      if (request.ArticlePartnerVat.Id > 0)
      {
        Datas.Instance.DataStorage.ArticlePartnerVats[request.ArticlePartnerVat.Id] = request.ArticlePartnerVat;
      }
      else
      {
        Datas.Instance.DataStorage.ArticlePartnerVats.Add(request.ArticlePartnerVat);
      }
      return request.ArticlePartnerVat;
    }
  }
}
