using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.ServiceInterface;
using ServiceStack.OrmLite;

namespace Bm2s.Data.Services.Article.ArticleSubFamily
{
  public class ArticleSubFamilyService : Service
  {
    public object Get(ArticleSubFamiliesRequest request)
    {
      ArticleSubFamilyResponse response = new ArticleSubFamilyResponse();

      if(!request.ArticleSubFamiliesIds.Any()) 
      {
        response.ArticleSubFamilies = this.Db.Select<BLL.Article.ArticleSubFamily>();
      }
      else
      {
        response.ArticleSubFamilies = this.Db.Where<BLL.Article.ArticleSubFamily>(item => request.ArticleSubFamiliesIds.Contains(item.Id));
      }

      return response;
    }

    public object Post(ArticleSubFamiliesRequest request)
    {
      return request.SubFamily;
    }
  }
}
