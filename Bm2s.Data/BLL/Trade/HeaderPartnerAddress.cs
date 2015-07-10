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
    [References(typeof(Header))]
    public int HeaderId { get; set; }

    [ForeignKey("HeaderId")]
    public Header Header { get; set; }

    [References(typeof(Address))]
    public int AddressId { get; set; }

    [ForeignKey("AddressId")]
    public Address Address { get; set; }

    [References(typeof(AddressType))]
    public int AddressTypeId { get; set; }

    [ForeignKey("AddressTypeId")]
    public AddressType AddressType { get; set; }

    [References(typeof(Partner.Partner))]
    public int PartnerId { get; set; }

    [ForeignKey("PartnerId")]
    public Partner.Partner Partner { get; set; }
  }
}
