using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Partner
{
  [Alias("Adli")]
  public class AddressLine : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public int Order { get; set; }

    [Required]
    public string Line { get; set; }

    [Alias("AddrId")]
    [References(typeof(Address))]
    public int AddressId { get; set; }
  }
}
