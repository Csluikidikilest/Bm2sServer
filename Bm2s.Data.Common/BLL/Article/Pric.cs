using System;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Article
{
  public class Pric : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Default(0)]
    public double BasePrice { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [References(typeof(Arti))]
    public int ArtId { get; set; }
  }
}
