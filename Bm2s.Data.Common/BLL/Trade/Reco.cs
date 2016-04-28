using System;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Trade
{
  public class Reco : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public double Amount { get; set; }

    [References(typeof(Paym))]
    public int PaymId { get; set; }

    [References(typeof(Heli))]
    public int HeliId { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }
  }
}
