using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.Trade.PaymentMode
{
  public class PaymentModesResponse
  {
    public PaymentModesResponse()
    {
      this.PaymentModes = new List<Bm2s.Data.Common.BLL.Trade.PaymentMode>();
    }

    public List<Bm2s.Data.Common.BLL.Trade.PaymentMode> PaymentModes { get; set; }
  }
}
