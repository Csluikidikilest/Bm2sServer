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
  public class ArticleSubFamilyResponse
  {

    public List<BLL.Article.ArticleSubFamily> ArticleSubFamilies { get; set; }
  }
}
