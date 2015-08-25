using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Article.Subscription
{
  [Route("/bm2s/subscriptions", Verbs = "GET, POST")]
  [Route("/bm2s/subscriptions/{Ids}", Verbs = "GET")]
  public class Subscriptions : IReturn<SubscriptionsResponse>
  {
    public Subscriptions()
    {
      this.Ids = new List<int>();
    }

    public int ArticleId { get; set; }

    public string Code { get; set; }

    public DateTime? Date { get; set; }

    public string Designation { get; set; }

    public List<int> Ids { get; set; }

    public Bm2s.Poco.Common.Article.Subscription Subscription { get; set; }
  }
}
