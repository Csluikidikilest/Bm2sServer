using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Trade
{
  public class Hefr : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Reference { get; set; }

    [References(typeof(Hest))]
    public int HestId { get; set; }
  }
}
