using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Trade
{
  public class HeaderFreeReference
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [Required]
    [StringLength(50)]
    public string Reference { get; set; }

    [References(typeof(HeaderStatus))]
    public int HeaderStatusId { get; set; }
  }
}
