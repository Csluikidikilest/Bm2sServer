using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Data.BLL.Article;
using Bm2s.Data.BLL.Parameter;
using Bm2s.Data.BLL.Sell;

namespace Bm2s.Data.BLL.Partner
{
  public class Partner
  {
    public int Id { get; private set; }
    public string Code { get; set; }
    public string CompanyName { get; set; }
    public string PhoneNumber { get; set; }
    public string FaxNumber { get; set; }
    public string WebSite { get; set; }
    public string Siret { get; set; }
    public string Email { get; set; }
    public string Observation { get; set; }
    public decimal PriceMultiplier { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }
    public bool IsCustomer { get; set; }
    public bool IsSupplier { get; set; }
    public User.User User { get; set; }
    public Address Address { get; set; }
    public List<ArticleFamilyPricePartner> ArticleFamilyPricePartners { get; set; }
    public List<ArticlePriceParner> ArticlePriceParners { get; set; }
    public List<ArticleSubFamilyPricePartner> ArticleSubFamilyPricePartners { get; set; }
    public List<ArticleFamilyPartnerVat> ArticleFamilyPartnerVats { get; set; }
    public List<ArticlePartnerVat> ArticlePartnerVats { get; set; }
    public List<ArticleSubFamilyPartnerVat> ArticleSubFamilyPartnerVats { get; set; }
    public List<PartnerAddress> PartnerAddresses { get; set; }
    public List<PartnerContact> PartnerContacts { get; set; }
    public List<PartnerFile> PartnerFiles { get; set; }
    public List<PartnerPartnerFamily> PartnerPartnerFamilies { get; set; }
    public List<HeaderPartnerAddress> HeaderPartnerAddresses { get; set; }
    public List<Payment> Payments { get; set; }
  }
}
