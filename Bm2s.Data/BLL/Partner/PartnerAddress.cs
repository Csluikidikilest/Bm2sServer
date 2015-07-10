using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Partner
{
  public class PartnerAddress
  {
    [PrimaryKey]
    [References(typeof(Address))]
    public int AddressId { get; set; }

    [ForeignKey("AddressId")]
    public Address Address { get; set; }

    [PrimaryKey]
    [References(typeof(AddressType))]
    public int AddressTypeId { get; set; }

    [ForeignKey("AddressTypeId")]
    public AddressType AddressType { get; set; }

    [PrimaryKey]
    [References(typeof(Partner))]
    public int PartnerId { get; set; }

    [ForeignKey("PartnerId")]
    public Partner Partner { get; set; }
  }
}
