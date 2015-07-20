using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Article.Article
{
  public class ArticlesResponse
  {
    public ArticlesResponse()
    {
      this.Articles = new List<BLL.Article.Article>();
    }

    public List<BLL.Article.Article> Articles { get; set; }
  }
}
