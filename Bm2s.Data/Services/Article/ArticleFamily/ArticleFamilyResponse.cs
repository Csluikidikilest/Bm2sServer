using Bm2s.Data.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Services.Article.ArticleFamily
{
  public class ArticleFamilyResponse
  {
    public Tables<BLL.Article.ArticleFamily> ArticleFamilies { get; set; }
  }
}
