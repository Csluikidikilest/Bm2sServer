using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Data.Common.Utils;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Trade
{
  public class Reconciliation : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public double Amount { get; set; }

    [References(typeof(Payment))]
    public int PaymentId { get; set; }

    [Ignore]
    public Payment Payment { get; set; }

    [References(typeof(HeaderLine))]
    public int HeaderLineId { get; set; }

    [Ignore]
    public HeaderLine HeaderLine { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.Payment = Datas.Instance.DataStorage.Payments.FirstOrDefault<Payment>(item => item.Id == this.PaymentId);
      this.HeaderLine = Datas.Instance.DataStorage.HeaderLines.FirstOrDefault<HeaderLine>(item => item.Id == this.HeaderLineId);
    }
  }
}
