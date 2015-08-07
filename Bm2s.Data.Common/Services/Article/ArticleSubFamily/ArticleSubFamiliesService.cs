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
          (string.IsNullOrWhiteSpace(request.AccountingEntry) || item.AccountingEntry.ToLower().Contains(request.AccountingEntry.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Designation) || item.Designation.ToLower().Contains(request.Designation.ToLower())) &&
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
