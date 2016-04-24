using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class Town : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [StringLength(50)]
    public string ZipCode { get; set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [References(typeof(Coun))]
    public int CounId { get; set; }
  }
}
