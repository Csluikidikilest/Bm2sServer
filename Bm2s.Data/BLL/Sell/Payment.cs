using Bm2s.Data.BLL.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Sell
{
  public class Payment
  {
    [AutoIncrement] [PrimaryKey] public int Id { get; private set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; }
    public Partner.Partner Partner { get; set; }
    public PaymentMode PaymentMode { get; set; }
    public Unit Unit { get; set; }
    public List<Reconciliation> Reconciliations { get; set; }
  }
}
