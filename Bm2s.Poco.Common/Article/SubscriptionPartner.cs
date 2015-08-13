
namespace Bm2s.Poco.Common.Article
{
  public class SubscriptionPartner
  {
    public int Id { get; set; }

    public Subscription Subscription { get; set; }

    public Partner.Partner Partner { get; set; }
  }
}
