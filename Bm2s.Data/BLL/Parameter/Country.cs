using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Parameter
{
  public class Country
  {
    public int Id { get; private set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }
    public Town Town { get; set; }
    public List<Town> Towns { get; set; }
    public List<CountryCurrency> CountryCurrencies { get; set; }
  }
}
