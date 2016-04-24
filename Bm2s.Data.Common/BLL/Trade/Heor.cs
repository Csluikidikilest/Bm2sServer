using System;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Trade
{
  public class Heor : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public DateTime Date { get; set; }

    [References(typeof(Head))]
    public int HepaId { get; set; }

    [References(typeof(Head))]
    public int HechId { get; set; }
  }
}
