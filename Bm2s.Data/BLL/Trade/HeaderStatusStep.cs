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
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [References(typeof(HeaderStatus))]
    public int HeaderStatusParentId { get; set; }

    [References(typeof(HeaderStatus))]
    public int HeaderStatusChildId { get; set; }
  }
}
