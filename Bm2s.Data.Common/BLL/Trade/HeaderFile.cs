using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Trade
{
  [Alias("Hefi")]
  public class HeaderFile : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    public Byte[] Content { get; set; }

    public DateTime AddingDate { get; set; }

    [Alias("HeadId")]
    [References(typeof(Header))]
    public int HeaderId { get; set; }

    [Alias("UserId")]
    [References(typeof(User.User))]
    public int UserId { get; set; }
  }
}
