using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Partner
{
  public class Adli : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public int Order { get; set; }

    [Required]
    public string Line { get; set; }

    [References(typeof(Addr))]
    public int AddrId { get; set; }
  }
}
