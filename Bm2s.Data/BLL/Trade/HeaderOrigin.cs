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
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    public DateTime Date { get; set; }

    [References(typeof(Header))]
    public int HeaderParentId { get; set; }

    [References(typeof(Header))]
    public int HeaderChildId { get; set; }
  }
}
