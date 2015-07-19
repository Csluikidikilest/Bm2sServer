using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.ServiceInterface;
using ServiceStack.OrmLite;
using Bm2s.Data.Utils;
using Bm2s.Data.BLL;

namespace Bm2s.Data.Services.Article.ArticleSubFamily
{
  public class ArticleSubFamilyService : Service
  {
    public object Get(ArticleSubFamiliesRequest request)
    {
      ArticleSubFamilyResponse response = new ArticleSubFamilyResponse();

      if (!request.ArticleSubFamiliesIds.Any())
      {
        response.ArticleSubFamilies = Datas.Instance.DataStorage.ArticleSubFamilies;
      }
      else
      {
        response.ArticleSubFamilies = (Tables<BLL.Article.ArticleSubFamily>)Datas.Instance.DataStorage.ArticleSubFamilies.Where(item => request.ArticleSubFamiliesIds.Contains(item.Id));
      }

      return response;
    }

    public object Post(ArticleSubFamiliesRequest request)
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
