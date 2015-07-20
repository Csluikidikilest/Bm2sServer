using Bm2s.Data.Utils;
using ServiceStack.ServiceInterface;
using System.Linq;

namespace Bm2s.Data.Services.Article.ArticleSubFamily
{
  public class ArticleSubFamiliesService : Service
  {
    public object Get(ArticleSubFamilies request)
    {
      ArticleSubFamiliesResponse response = new ArticleSubFamiliesResponse();

      if (!request.Ids.Any())
      {
        response.ArticleSubFamilies.AddRange(Datas.Instance.DataStorage.ArticleSubFamilies);
      }
      else
      {
        response.ArticleSubFamilies.AddRange(Datas.Instance.DataStorage.ArticleSubFamilies.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(ArticleSubFamilies request)
    {
      if (request.ArticleSubFamily.Id > 0)
      {
        Datas.Instance.DataStorage.ArticleSubFamilies[request.ArticleSubFamily.Id] = request.ArticleSubFamily;
      }
      else
      {
        Datas.Instance.DataStorage.ArticleSubFamilies.Add(request.ArticleSubFamily);
      }
      return request.ArticleSubFamily;
    }
  }
}
