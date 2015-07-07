using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Data.BLL.Parameter;
using Bm2s.Data.BLL.Partner;

namespace Bm2s.Data.BLL.Sell
{
  public class Header
  {
    public int Id { get; set; }
    public string Reference { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime? EndingDate { get; set; }
    public string Description { get; set; }
    public string DeliveryObservation { get; set; }
    public decimal FooterDiscount { get; set; }
    public bool IsSell { get; set; }
    public Activity Activity { get; set; }
    public User.User User { get; set; }
    public HeaderStatus HeaderStatus { get; set; }
    public List<AffairHeader> AffairHeaders { get; set; }
    public List<HeaderFile> HeaderFiles { get; set; }
    public List<HeaderLine> HeaderLines { get; set; }
    public List<HeaderOrigin> HeaderOriginParents { get; set; }
    public List<HeaderOrigin> HeaderOriginChildren { get; set; }
    public List<HeaderPartnerAddress> HeaderPartnerAddresses { get; set; }
  }
}
