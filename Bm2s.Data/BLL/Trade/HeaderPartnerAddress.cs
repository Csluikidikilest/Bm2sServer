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
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [References(typeof(Header))]
    public int HeaderId { get; set; }

    [References(typeof(Address))]
    public int AddressId { get; set; }

    [References(typeof(AddressType))]
    public int AddressTypeId { get; set; }

    [References(typeof(Partner.Partner))]
    public int PartnerId { get; set; }
  }
}
