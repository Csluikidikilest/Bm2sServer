using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Bm2s.Data.BLL.Trade
{
  public class HeaderFreeReference : Table
  {
    [Required]
    [StringLength(50)]
    public string Reference { get; set; }

    [References(typeof(HeaderStatus))]
    public int HeaderStatusId { get; set; }

    [Ignore]
    public HeaderStatus HeaderStatus { get; set; }
  }
}
