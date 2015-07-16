using Bm2s.Data.Utils;
using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;

namespace Bm2s.Data.Services.Article.ArticleSubFamily
{
  public class ArticleSubFamily : BLL.Article.ArticleSubFamily, IReturn<ArticleSubFamily>
  {
    public BLL.Article.ArticleFamily ArticleFamily
    {
      get
      {
        return Datas.Instance.DbConnection.Where<BLL.Article.ArticleFamily>(item => item.Id == this.ArticleFamilyId).FirstOrDefault();
      }
    }
  }
}
