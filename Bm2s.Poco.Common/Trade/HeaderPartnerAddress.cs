using System.Linq;
using Bm2s.Poco.Common.Partner;

namespace Bm2s.Poco.Common.Trade
{
  public class HeaderPartnerAddress
  {
    public int Id { get; set; }

    public Header Header { get; set; }

    public Address Address { get; set; }

    public AddressType AddressType { get; set; }

    public Partner.Partner Partner { get; set; }
  }
}
