using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Data.BLL.Article;
using Bm2s.Data.BLL.Parameter;
using Bm2s.Data.BLL.Trade;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Partner
{
  public class Partner
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [Required]
    [StringLength(250)]
    public string Code { get; set; }

    [StringLength(250)]
    public string CompanyName { get; set; }

    [StringLength(20)]
    public string PhoneNumber { get; set; }

    [StringLength(20)]
    public string FaxNumber { get; set; }

    public string WebSite { get; set; }

    public string CompanyIdentifier { get; set; }

    [StringLength(255)]
    public string Email { get; set; }

    public string Observation { get; set; }

    [Default(1)]
    public double? PriceMultiplier { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public bool IsCustomer { get; set; }

    public bool IsSupplier { get; set; }

    [References(typeof(User.User))]
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public User.User User { get; set; }

    [InverseProperty("Partner")]
    public List<ArticleFamilyPricePartner> ArticleFamilyPricePartners { get; set; }

    [InverseProperty("Partner")]
    public List<ArticlePriceParner> ArticlePriceParners { get; set; }

    [InverseProperty("Partner")]
    public List<ArticleSubFamilyPricePartner> ArticleSubFamilyPricePartners { get; set; }

    [InverseProperty("Partner")]
    public List<ArticleFamilyPartnerVat> ArticleFamilyPartnerVats { get; set; }

    [InverseProperty("Partner")]
    public List<ArticlePartnerVat> ArticlePartnerVats { get; set; }

    [InverseProperty("Partner")]
    public List<ArticleSubFamilyPartnerVat> ArticleSubFamilyPartnerVats { get; set; }

    [InverseProperty("Partner")]
    public List<PartnerAddress> PartnerAddresses { get; set; }

    [InverseProperty("Partner")]
    public List<PartnerContact> PartnerContacts { get; set; }

    [InverseProperty("Partner")]
    public List<PartnerFile> PartnerFiles { get; set; }

    [InverseProperty("Partner")]
    public List<PartnerPartnerFamily> PartnerPartnerFamilies { get; set; }

    [InverseProperty("Partner")]
    public List<HeaderPartnerAddress> HeaderPartnerAddresses { get; set; }

    [InverseProperty("Partner")]
    public List<Payment> Payments { get; set; }
  }
}
