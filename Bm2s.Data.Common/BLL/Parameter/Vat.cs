using System;
using System.ComponentModel.DataAnnotations;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class Vat : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Required]
    [StringLength(250)]
    public string Code { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public double Rate { get; set; }

    [StringLength(50)]
    public string AccountingEntry { get; set; }
  }
}
