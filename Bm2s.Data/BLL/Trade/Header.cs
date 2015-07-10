using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Data.BLL.Parameter;
using Bm2s.Data.BLL.Partner;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Trade
{
  public class Header
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [Required]
    [StringLength(50)]
    public string Reference { get; set; }

    public DateTime Date { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public string Description { get; set; }

    public string DeliveryObservation { get; set; }

    public double FooterDiscount { get; set; }

    public bool IsSell { get; set; }

    [References(typeof(Activity))]
    public int ActivityId { get; set; }

    [ForeignKey("ActivityId")]
    public Activity Activity { get; set; }

    [References(typeof(User.User))]
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public User.User User { get; set; }

    [References(typeof(HeaderStatus))]
    public int HeaderStatusId { get; set; }

    [ForeignKey("HeaderStatusId")]
    public HeaderStatus HeaderStatus { get; set; }

    [InverseProperty("Header")]
    public List<AffairHeader> AffairHeaders { get; set; }

    [InverseProperty("Header")]
    public List<HeaderFile> HeaderFiles { get; set; }

    [InverseProperty("Header")]
    public List<HeaderLine> HeaderLines { get; set; }

    [InverseProperty("HeaderParent")]
    public List<HeaderOrigin> HeaderOriginParents { get; set; }

    [InverseProperty("HeaderChild")]
    public List<HeaderOrigin> HeaderOriginChildren { get; set; }

    [InverseProperty("Header")]
    public List<HeaderPartnerAddress> HeaderPartnerAddresses { get; set; }
  }
}
