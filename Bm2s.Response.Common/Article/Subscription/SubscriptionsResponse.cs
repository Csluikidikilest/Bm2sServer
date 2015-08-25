using System.Collections.Generic;

namespace Bm2s.Response.Common.Article.Subscription
{
  public class SubscriptionsResponse
  {
    public SubscriptionsResponse()
    {
      this.Subscriptions = new List<Poco.Common.Article.Subscription>();
    }

    public List<Bm2s.Poco.Common.Article.Subscription> Subscriptions { get; set; }
  }
}
