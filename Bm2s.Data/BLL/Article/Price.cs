using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Article
{
  public class Price
  {
    public int Id { get; private set; }
    public decimal Price { get; set; }
    public decimal Multiplier { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }
    public Article Article { get; set; }
  }
}
