using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Response.Common.Trade.PaymentMode
{
  public class PaymentModesResponse : Response
  {
    public PaymentModesResponse()
    {
      this.PaymentModes = new List<Bm2s.Poco.Common.Trade.PaymentMode>();
    }

    public List<Bm2s.Poco.Common.Trade.PaymentMode> PaymentModes { get; set; }
  }
}
