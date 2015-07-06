using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Parameter
{
  public class Activity
  {
    public int Id { get; set;}
    public string CompanyName { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string Address3 { get; set; }
    public string TownZipCode { get; set; }
    public string TownName { get; set; }
    public string CountryName { get; set; }
    public List<Affair> Affairs { get; set; }
  }
}
