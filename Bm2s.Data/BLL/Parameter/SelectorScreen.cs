using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class SelectorScreen
  {
    [AutoIncrement] [PrimaryKey] public int Id { get; private set; }
    [Required] [StringLength(50)] public string Code { get; set; }
    public string HeaderText { get; set; }
    public List<SelectorColumn> SelectorColumns { get; set; }
  }
}
