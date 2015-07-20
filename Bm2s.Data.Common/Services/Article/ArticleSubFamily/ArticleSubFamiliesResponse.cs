using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Article.ArticleSubFamily
{
  public class ArticleSubFamiliesResponse
  {
    public ArticleSubFamiliesResponse()
    {
      this.ArticleSubFamilies = new List<BLL.Article.ArticleSubFamily>();
    }

    public List<BLL.Article.ArticleSubFamily> ArticleSubFamilies { get; set; }
  }
}
