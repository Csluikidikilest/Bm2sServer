using System.Collections.Generic;

namespace Bm2s.Services.Common.Article.ArticleSubFamily
{
  public class ArticleSubFamiliesResponse
  {
    public ArticleSubFamiliesResponse()
    {
      this.ArticleSubFamilies = new List<Bm2s.Data.Common.BLL.Article.ArticleSubFamily>();
    }

    public List<Bm2s.Data.Common.BLL.Article.ArticleSubFamily> ArticleSubFamilies { get; set; }
  }
}
