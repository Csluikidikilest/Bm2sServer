using System;
using System.Linq;
using Bm2s.Data.Common.BLL.Parameter;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Trade
{
  public class Payment : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public double Amount { get; set; }

    public DateTime Date { get; set; }

    [References(typeof(Partner.Partner))]
    public int PartnerId { get; set; }

    [Ignore]
    public Partner.Partner Partner { get; set; }

    [References(typeof(PaymentMode))]
    public int PaymentModeId { get; set; }

    [Ignore]
    public PaymentMode PaymentMode { get; set; }

    [References(typeof(Unit))]
    public int UnitId { get; set; }

    [Ignore]
    public Unit Unit { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.Partner = Datas.Instance.DataStorage.Partners.FirstOrDefault<Partner.Partner>(item => item.Id == this.PartnerId);
      this.PaymentMode = Datas.Instance.DataStorage.PaymentModes.FirstOrDefault<PaymentMode>(item => item.Id == this.PaymentModeId);
      this.Unit = Datas.Instance.DataStorage.Units.FirstOrDefault<Unit>(item => item.Id == this.UnitId);
    }
  }
}
