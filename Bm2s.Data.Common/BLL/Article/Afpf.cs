using System;
using System.Linq;
using Bm2s.Data.Common.BLL.Partner;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Article
{
  public class Afpf : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Default(0)]
    public double? Price { get; set; }

    [Default(1)]
    public double? Multiplier { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [References(typeof(Arfa))]
    public int ArfaId { get; set; }

    [References(typeof(Pafa))]
    public int PafaId { get; set; }
  }
}
