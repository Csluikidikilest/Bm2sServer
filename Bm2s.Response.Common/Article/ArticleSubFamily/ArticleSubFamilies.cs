using ServiceStack.ServiceHost;
using System.Collections.Generic;
using System;

namespace Bm2s.Response.Common.Article.ArticleSubFamily
{
  [Route("/bm2s/articlesubfamilies", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/articlesubfamilies/{Ids}", Verbs = "GET")]
  public class ArticleSubFamilies : Request, IReturn<ArticleSubFamiliesResponse>
  {
    public ArticleSubFamilies()
    {
      this.Ids = new List<int>();
    }

    public string AccountingEntry { get; set; }

    public int ArticleFamilyId { get; set; }

    public string Code { get; set; }

    public DateTime? Date { get; set; }

    public string Designation { get; set; }

    public Bm2s.Poco.Common.Article.ArticleSubFamily ArticleSubFamily { get; set; }
  }
}
