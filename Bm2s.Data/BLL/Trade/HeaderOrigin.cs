using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Trade
{
  public class HeaderOrigin
  {
    public DateTime Date { get; set; }

    [PrimaryKey]
    [References(typeof(Header))]
    public int HeaderParentId { get; set; }

    [ForeignKey("HeaderParentId")]
    public Header HeaderParent { get; set; }

    [PrimaryKey]
    [References(typeof(Header))]
    public int HeaderChildId { get; set; }

    [ForeignKey("HeaderChildId")]
    public Header HeaderChild { get; set; }
  }
}
