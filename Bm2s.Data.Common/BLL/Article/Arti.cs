using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.BLL.Parameter;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Article
{
  public class Arti : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Required]
    [StringLength(250)]
    public string Code { get; set; }

    [Required]
    [StringLength(250)]
    public string Designation { get; set; }

    public string Description { get; set; }

    public string Observation { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [References(typeof(Arfa))]
    public int ArfaId { get; set; }

    [References(typeof(Arsf))]
    public int ArsfId { get; set; }

    [References(typeof(Bran))]
    public int BranId { get; set; }

    [References(typeof(Unit))]
    public int UnitId { get; set; }
  }
}
