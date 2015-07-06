using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Parameter
{
  public class SelectorScreen
  {
    public int Id { get; private set; }
    public string Code { get; set; }
    public string HeaderText { get; set; }
    public List<SelectorColumn> SelectorColumns { get; set; }
  }
}
