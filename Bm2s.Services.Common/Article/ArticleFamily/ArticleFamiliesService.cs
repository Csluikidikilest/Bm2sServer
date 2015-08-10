using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System.Linq;

namespace Bm2s.Services.Common.Article.ArticleFamily
{
  public class ArticleFamiliesService : Service
  {
    public object Get(ArticleFamilies request)
    {
      ArticleFamiliesResponse response = new ArticleFamiliesResponse();

      if (!request.Ids.Any())
      {
        response.ArticleFamilies.AddRange(Datas.Instance.DataStorage.ArticleFamilies.Where(item =>
          (string.IsNullOrWhiteSpace(request.AccountingEntry) || item.AccountingEntry.ToLower().Contains(request.AccountingEntry.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Designation) || item.Designation.ToLower().Contains(request.Designation.ToLower())) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        response.ArticleFamilies.AddRange(Datas.Instance.DataStorage.ArticleFamilies.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(ArticleFamilies request)
    {
      if (request.ArticleFamily.Id > 0)
      {
        Datas.Instance.DataStorage.ArticleFamilies[request.ArticleFamily.Id] = request.ArticleFamily;
      }
      else
      {
        Datas.Instance.DataStorage.ArticleFamilies.Add(request.ArticleFamily);
      }
      return request.ArticleFamily;
    }
  }
}
