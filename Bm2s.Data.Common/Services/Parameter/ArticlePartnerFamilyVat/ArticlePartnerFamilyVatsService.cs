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
        response.ArticlePartnerFamilyVats.AddRange(Datas.Instance.DataStorage.ArticlePartnerFamilyVats);
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
