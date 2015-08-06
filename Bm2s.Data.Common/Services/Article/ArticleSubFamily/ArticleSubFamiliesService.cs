using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System.Linq;

namespace Bm2s.Data.Common.Services.Article.ArticleSubFamily
{
  public class ArticleSubFamiliesService : Service
  {
    public object Get(ArticleSubFamilies request)
    {
      ArticleSubFamiliesResponse response = new ArticleSubFamiliesResponse();

      if (!request.Ids.Any())
      {
        response.ArticleSubFamilies.AddRange(Datas.Instance.DataStorage.ArticleSubFamilies.Where(item =>
          (string.IsNullOrWhiteSpace(request.AccountingEntry) || item.AccountingEntry.Contains(request.AccountingEntry)) &&
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.Contains(request.Code)) &&
          (string.IsNullOrWhiteSpace(request.Designation) || item.Designation.Contains(request.Designation)) &&
          (request.ArticleFamilyId == 0 || item.ArticleFamilyId == request.ArticleFamilyId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
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
