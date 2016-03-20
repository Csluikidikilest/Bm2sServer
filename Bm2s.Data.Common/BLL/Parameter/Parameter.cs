using System;
using System.ComponentModel.DataAnnotations;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class Parameter : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Required]
    [StringLength(250)]
    public string Code { get; set; }

    [Required]
    [StringLength(250)]
    public string Description { get; set; }

    [Required]
    [StringLength(1)]
    public string ValueType { get; set; }

    public string sValue { get; set; }

    public int iValue { get; set; }

    public double fValue { get; set; }

    public bool bValue { get; set; }

    public DateTime dValue { get; set; }

    public bool IsSystem { get; set; }

    public bool IsOverloadable { get; set; }
  }
}
