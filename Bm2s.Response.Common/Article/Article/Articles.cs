using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Article.Article
{
  [Route("/bm2s/articles", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/articles/{Ids}", Verbs = "GET")]
  public class Articles : Request, IReturn<ArticlesResponse>
  {
    public Articles()
    {
      this.Ids = new List<int>();
    }

    public int ArticleFamilyId { get; set; }

    public int ArticleSubFamilyId { get; set; }

    public int BrandId { get; set; }

    public string Code { get; set; }

    public DateTime? Date { get; set; }

    public string Designation { get; set; }

    public Bm2s.Poco.Common.Article.Article Article { get; set; }
  }
}
