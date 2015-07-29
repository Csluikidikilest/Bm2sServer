using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Article
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

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.Partner = Datas.Instance.DataStorage.Partners.FirstOrDefault<Partner.Partner>(item => item.Id == this.PartnerId);
    }
  }
}
