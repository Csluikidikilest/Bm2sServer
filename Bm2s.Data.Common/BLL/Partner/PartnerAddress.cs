using ServiceStack.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.Utils;

namespace Bm2s.Data.Common.BLL.Partner
{
  public class PartnerAddress : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

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

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.Address = Datas.Instance.DataStorage.Addresses.FirstOrDefault<Address>(item => item.Id == this.AddressId);
      this.AddressType = Datas.Instance.DataStorage.AddressTypes.FirstOrDefault<AddressType>(item => item.Id == this.AddressTypeId);
      this.Partner = Datas.Instance.DataStorage.Partners.FirstOrDefault<Partner>(item => item.Id == this.PartnerId);
    }
  }
}
