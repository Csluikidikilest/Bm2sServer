using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Trade.Payment
{
  public class PaymentsResponse
  {
    public PaymentsResponse()
    {
      this.Payments = new List<BLL.Trade.Payment>();
    }

    public List<BLL.Trade.Payment> Payments { get; set; }
  }
}
