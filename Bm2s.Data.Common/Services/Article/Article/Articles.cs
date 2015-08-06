using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Article.Article
{
  [Route("/bm2s/articles", Verbs = "GET, POST")]
  [Route("/bm2s/articles/{Ids}", Verbs = "GET")]
  public class Articles : IReturn<ArticlesResponse>
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

    public List<int> Ids { get; set; }

    public BLL.Article.Article Article { get; set; }
  }
}
