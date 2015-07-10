using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Partner
{
  public class PartnerPartnerFamily
  {
    [References(typeof(Partner))]
    public int PartnerId { get; set; }

    [ForeignKey("PartnerId")]
    public Partner Partner { get; set; }

    [References(typeof(PartnerFamily))]
    public int PartnerFamilyId { get; set; }

    [ForeignKey("PartnerFamilyId")]
    public PartnerFamily PartnerFamily { get; set; }
  }
}
