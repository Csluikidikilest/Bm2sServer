using ServiceStack.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class SelectorScreen : Table
  {
    [Required]
    [StringLength(250)]
    public string Code { get; set; }

    public string HeaderText { get; set; }
  }
}
