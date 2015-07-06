using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Sell
{
  public class PaymentMode
  {
    public int Id { get; private set; }
    public string Name { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }
    public List<Payment> Payments { get; set; }
  }
}
