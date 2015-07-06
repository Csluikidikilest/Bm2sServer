using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Parameter
{
  public class Parameter
  {
    public int Id { get; private set; }
    public string Code { get; set; }
    public string ValueType { get; set; }
    public string sValue { get; set; }
    public int iValue { get; set; }
    public decimal fValue { get; set; }
    public bool bValue { get; set; }
    public DateTime dValue { get; set; }
  }
}
