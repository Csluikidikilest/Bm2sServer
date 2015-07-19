using Bm2s.Data.BLL;
using Bm2s.Data.Utils;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Services.Article.ArticleFamily
{
  public class ArticleFamilyService : Service
  {
    public object Get(ArticleFamiliesRequest request)
    {
      ArticleFamilyResponse response = new ArticleFamilyResponse();

      if (!request.ArticleFamiliesIds.Any())
      {
        response.ArticleFamilies = Datas.Instance.DataStorage.ArticleFamilies;
      }
      else
      {
        response.ArticleFamilies = (Tables<BLL.Article.ArticleFamily>)Datas.Instance.DataStorage.ArticleFamilies.Where(item => request.ArticleFamiliesIds.Contains(item.Id));
      }

      return response;
    }

    public object Post(ArticleFamiliesRequest request)
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
