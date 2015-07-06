using Bm2s.Data.BLL.Sell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Article
{
  public class Brand
  {
    public int Id { get; private set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }
    public List<Article> Articles { get; set; }
    public List<HeaderLine> HeaderLines { get; set; }
  }
}
