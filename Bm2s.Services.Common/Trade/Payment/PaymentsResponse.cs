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
      this.Payments = new List<Bm2s.Poco.Common.Trade.Payment>();
    }

    public List<Bm2s.Poco.Common.Trade.Payment> Payments { get; set; }
  }
}
