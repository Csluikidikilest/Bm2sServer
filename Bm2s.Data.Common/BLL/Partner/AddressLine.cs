using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.Utils;

namespace Bm2s.Data.Common.BLL.Partner
{
  public class AddressLine : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public int Order { get; set; }

    [Required]
    public string Line { get; set; }

    [References(typeof(Address))]
    public int AddressId { get; set; }

    [Ignore]
    public Address Address { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.Address = Datas.Instance.DataStorage.Addresses.FirstOrDefault<Address>(item => item.Id == this.AddressId);
    }
  }
}
