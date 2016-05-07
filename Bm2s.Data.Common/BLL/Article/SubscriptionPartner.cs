using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Article
{
  [Alias("Supa")]
  public class SubscriptionPartner : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Alias("SubsId")]
    [References(typeof(Subscription))]
    public int SubscriptionId { get; set; }

    [Alias("PartId")]
    [References(typeof(Partner.Partner))]
    public int PartnerId { get; set; }
  }
}
