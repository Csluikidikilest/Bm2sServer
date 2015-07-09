using Bm2s.Data.BLL.Partner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Trade
{
  public class HeaderPartnerAddress
  {
    public Header Header { get; set; }
    public Address Address { get; set; }
    public AddressType AddressType { get; set; }
    public Partner.Partner Partner { get; set; }
  }
}
