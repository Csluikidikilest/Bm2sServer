using System.Linq;
using Bm2s.Data.Common.BLL.Partner;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Trade
{
  public class HeaderPartnerAddress : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [References(typeof(Header))]
    public int HeaderId { get; set; }

    [Ignore]
    public Header Header { get; set; }

    [References(typeof(Address))]
    public int AddressId { get; set; }

    [Ignore]
    public Address Address { get; set; }

    [References(typeof(AddressType))]
    public int AddressTypeId { get; set; }

    [Ignore]
    public AddressType AddressType { get; set; }

    [References(typeof(Partner.Partner))]
    public int PartnerId { get; set; }

    [Ignore]
    public Partner.Partner Partner { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.Address = Datas.Instance.DataStorage.Addresses.FirstOrDefault<Address>(item => item.Id == this.AddressId);
      this.AddressType = Datas.Instance.DataStorage.AddressTypes.FirstOrDefault<AddressType>(item => item.Id == this.AddressTypeId);
      this.Header = Datas.Instance.DataStorage.Headers.FirstOrDefault<Header>(item => item.Id == this.HeaderId);
      this.Partner = Datas.Instance.DataStorage.Partners.FirstOrDefault<Partner.Partner>(item => item.Id == this.PartnerId);
    }
  }
}
