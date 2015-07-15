using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Data.BLL.Trade;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class AffairHeader
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [References(typeof(Affair))]
    public int AffairId { get; set; }

    [References(typeof(Header))]
    public int HeaderId { get; set; }
  }
}
