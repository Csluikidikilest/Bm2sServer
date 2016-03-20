using System;
using Bm2s.Poco.Common.Parameter;

namespace Bm2s.Poco.Common.Trade
{
  public class Header
  {
    public int Id { get; set; }

    public string Reference { get; set; }

    public DateTime Date { get; set; }

    public DateTime? EndingDate { get; set; }

    public string Description { get; set; }

    public string DeliveryObservation { get; set; }

    public decimal FooterDiscount { get; set; }

    public bool IsSell { get; set; }

    public Activity Activity { get; set; }

    public User.User User { get; set; }

    public HeaderStatus HeaderStatus { get; set; }
  }
}
