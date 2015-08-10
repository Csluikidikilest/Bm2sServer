using ServiceStack.ServiceHost;
using System.Collections.Generic;
using System;

namespace Bm2s.Services.Common.Article.ArticleSubFamily
{
  [Route("/bm2s/articlesubfamilies", Verbs = "GET, POST")]
  [Route("/bm2s/articlesubfamilies/{Ids}", Verbs = "GET")]
  public class ArticleSubFamilies : IReturn<ArticleSubFamiliesResponse>
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

    public List<int> Ids { get; set; }

    public Bm2s.Data.Common.BLL.Article.ArticleSubFamily ArticleSubFamily { get; set; }
  }
}
