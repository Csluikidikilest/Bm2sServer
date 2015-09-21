using System.Collections.Generic;

namespace Bm2s.Response.Common.Article.SubscriptionPartner
{
  public class SubscriptionPartnersResponse : Response
  {
    public SubscriptionPartnersResponse()
    {
      this.SubscriptionPartners = new List<Poco.Common.Article.SubscriptionPartner>();
    }

    public List<Bm2s.Poco.Common.Article.SubscriptionPartner> SubscriptionPartners { get; set; }
  }
}
