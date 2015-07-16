using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Article
{
  public class SubscriptionPartner : Table
  {
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
