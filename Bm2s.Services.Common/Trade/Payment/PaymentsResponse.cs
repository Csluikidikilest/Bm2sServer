using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.Trade.Payment
{
  public class PaymentsResponse
  {
    public PaymentsResponse()
    {
      this.Payments = new List<Bm2s.Data.Common.BLL.Trade.Payment>();
    }

    public List<Bm2s.Data.Common.BLL.Trade.Payment> Payments { get; set; }
  }
}
