
namespace Bm2s.Poco.Common.Partner
{
  public class PartnerAddress
  {
    public int Id { get; set; }

    public Address Address { get; set; }

    public AddressType AddressType { get; set; }

    public Partner Partner { get; set; }
  }
}
