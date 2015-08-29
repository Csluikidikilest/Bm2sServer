using ServiceStack.ServiceHost;
using System.Collections.Generic;
using System;

namespace Bm2s.Response.Common.Article.ArticleFamily
{
  [Route("/bm2s/articlefamilies", Verbs = "GET, POST")]
  [Route("/bm2s/articlefamilies/{Ids}", Verbs = "GET")]
  public class ArticleFamilies : Request, IReturn<ArticleFamiliesResponse>
  {
    public ArticleFamilies()
    {
      this.Ids = new List<int>();
    }

    public string AccountingEntry { get; set; }

    public string Code { get; set; }

    public DateTime? Date { get; set; }

    public string Designation { get; set; }

    public Bm2s.Poco.Common.Article.ArticleFamily ArticleFamily { get; set; }
  }
}
