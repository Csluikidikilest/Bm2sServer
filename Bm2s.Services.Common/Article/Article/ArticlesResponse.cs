using System.Collections.Generic;

namespace Bm2s.Services.Common.Article.Article
{
  public class ArticlesResponse
  {
    public ArticlesResponse()
    {
      this.Articles = new List<Bm2s.Data.Common.BLL.Article.Article>();
    }

    public List<Bm2s.Data.Common.BLL.Article.Article> Articles { get; set; }
  }
}
