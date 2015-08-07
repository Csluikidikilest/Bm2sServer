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
        response.Articles.AddRange(Datas.Instance.DataStorage.Articles.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Designation) || item.Designation.ToLower().Contains(request.Designation.ToLower())) &&
          (request.ArticleFamilyId == 0 || item.ArticleFamilyId == request.ArticleFamilyId) &&
          (request.ArticleSubFamilyId == 0 || item.ArticleSubFamilyId == request.ArticleSubFamilyId) &&
          (request.BrandId == 0 || item.BrandId == request.BrandId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        response.Articles.AddRange(Datas.Instance.DataStorage.Articles.Where(item => request.Ids.Contains(item.Id)));
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
