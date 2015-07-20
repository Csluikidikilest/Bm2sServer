using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System.Linq;

namespace Bm2s.Data.Common.Services.Article.Article
{
  public class ArticlesService : Service
  {
    public object Get(Articles request)
    {
      ArticlesResponse response = new ArticlesResponse();

      if (!request.Ids.Any())
      {
        response.Articles.AddRange(Datas.Instance.DataStorage.Articles);
      }
      else
      {
        response.Articles.AddRange(Datas.Instance.DataStorage.Articles.Where(arti => request.Ids.Contains(arti.Id)));
      }

      return response;
    }

    public object Post(Articles request)
    {
      if (request.Article.Id > 0)
      {
        Datas.Instance.DataStorage.Articles[request.Article.Id] = request.Article;
      }
      else
      {
        Datas.Instance.DataStorage.Articles.Add(request.Article);
      }
      return request.Article;
    }
  }
}
