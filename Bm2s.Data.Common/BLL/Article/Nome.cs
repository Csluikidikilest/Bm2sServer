using System;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Article
{
  public class Nome : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Default(1)]
    public double QuantityChild { get; set; }

    public double BuyPrice { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [References(typeof(Arti))]
    public int ArpaId { get; set; }

    [References(typeof(Arti))]
    public int ArchId { get; set; }
  }
}
