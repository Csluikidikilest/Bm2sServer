using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Article.SubscriptionPartner
{
  [Route("/bm2s/subscriptionpartners", Verbs = "GET, POST")]
  [Route("/bm2s/subscriptionpartners/{Ids}", Verbs = "GET")]
  public class SubscriptionPartners : Request, IReturn<SubscriptionPartnersResponse>
  {
    public SubscriptionPartners()
    {
      this.Ids = new List<int>();
    }

    public int SubscriptionId { get; set; }

    public int PartnerId { get; set; }

    public Bm2s.Poco.Common.Article.SubscriptionPartner SubscriptionPartner { get; set; }
  }
}
