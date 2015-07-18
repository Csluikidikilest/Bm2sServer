using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Partner
{
  public class PartnerAddress : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; protected set; }

    [References(typeof(Address))]
    public int AddressId { get; set; }

    [Ignore]
    public Address Address { get; set; }

    [References(typeof(AddressType))]
    public int AddressTypeId { get; set; }

    [Ignore]
    public AddressType AddressType { get; set; }

    [References(typeof(Partner))]
    public int PartnerId { get; set; }

    [Ignore]
    public Partner Partner { get; set; }
  }
}
