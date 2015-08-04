using ServiceStack.ServiceHost;
using System.Collections.Generic;
using System;

namespace Bm2s.Data.Common.Services.Article.ArticleFamily
{
  [Route("/bm2s/articlefamilies", Verbs = "GET, POST")]
  [Route("/bm2s/articlefamilies/{Ids}", Verbs = "GET")]
  public class ArticleFamilies : IReturn<ArticleFamiliesResponse>
  {
    public ArticleFamilies()
    {
      this.Ids = new List<int>();
    }

    public string AccountingEntry { get; set; }

    public string Code { get; set; }

    public DateTime? Date { get; set; }

    public string Designation { get; set; }

    public List<int> Ids { get; set; }

    public BLL.Article.ArticleFamily ArticleFamily { get; set; }
  }
}
