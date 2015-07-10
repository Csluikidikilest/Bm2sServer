using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Trade
{
  public class HeaderStatusStep
  {
    [PrimaryKey]
    [References(typeof(HeaderStatus))]
    public int HeaderStatusParentId { get; set; }

    [ForeignKey("HeaderStatusParentId")]
    public HeaderStatus HeaderStatusParent { get; set; }

    [PrimaryKey]
    [References(typeof(HeaderStatus))]
    public int HeaderStatusChildId { get; set; }

    [ForeignKey("HeaderStatusChildId")]
    public HeaderStatus HeaderStatusChild { get; set; }
  }
}
