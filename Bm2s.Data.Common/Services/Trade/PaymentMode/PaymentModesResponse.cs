using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Trade.PaymentMode
{
  public class PaymentModesResponse
  {
    public PaymentModesResponse()
    {
      this.PaymentModes = new List<BLL.Trade.PaymentMode>();
    }

    public List<BLL.Trade.PaymentMode> PaymentModes { get; set; }
  }
}
