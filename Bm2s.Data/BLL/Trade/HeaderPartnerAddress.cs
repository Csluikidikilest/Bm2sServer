using Bm2s.Data.BLL.Partner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bm2s.Data.BLL.Trade
{
  public class HeaderPartnerAddress
  {
    public int HeaderId { get; set; }

    public Header Header { get; set; }

    public int AddressId { get; set; }

    public Address Address { get; set; }

    public int AddressTypeId { get; set; }

    public AddressType AddressType { get; set; }

    [References(typeof(Partner.Partner))]
    public int PartnerId { get; set; }

    [ForeignKey("PartnerId")]
    public Partner.Partner Partner { get; set; }
  }
}
