using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.BLL.Parameter;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Trade
{
  public class Header : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Reference { get; set; }

    public DateTime Date { get; set; }

    public DateTime? EndingDate { get; set; }

    public string Description { get; set; }

    public string DeliveryObservation { get; set; }

    public double FooterDiscount { get; set; }

    public bool IsPurchase { get; set; }

    public bool IsSell { get; set; }

    [References(typeof(Activity))]
    public int ActivityId { get; set; }

    [References(typeof(User.User))]
    public int UserId { get; set; }

    [References(typeof(HeaderStatus))]
    public int HeaderStatusId { get; set; }
  }
}
