using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Article.ArticleFamily
{
  public class ArticleFamiliesResponse
  {
    public ArticleFamiliesResponse()
    {
      this.ArticleFamilies = new List<BLL.Article.ArticleFamily>();
    }

    public List<BLL.Article.ArticleFamily> ArticleFamilies { get; set; }
  }
}
