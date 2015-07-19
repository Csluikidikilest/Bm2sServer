using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Article
{
  public class SubscriptionPartner : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [References(typeof(Subscription))]
    public int SubscriptionId { get; set; }

    [Ignore]
    public Subscription Subscription { get; set; }

    [References(typeof(Partner.Partner))]
    public int PartnerId { get; set; }

    [Ignore]
    public Partner.Partner Partner { get; set; }
  }
}
