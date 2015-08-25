using Bm2s.Connectivity.Utils;
using Bm2s.Response.Common.Parameter.ArticleFamilyPartnerFamilyVat;

namespace Bm2s.Connectivity.Common.Parameter
{
  public class ArticleFamilyPartnerFamilyVat : ClientBase
  {
    public ArticleFamilyPartnerFamilyVat()
      : base()
    {
      this.Request = new ArticleFamilyPartnerFamilyVats();
      this.Response = new ArticleFamilyPartnerFamilyVatsResponse();
    }

    public ArticleFamilyPartnerFamilyVats Request { get; set; }

    public ArticleFamilyPartnerFamilyVatsResponse Response { get; set; }

    public void Get()
    {
      this.Response = this.ConnectorHelper.Get(this.Request);
      this.IsFilled = true;
    }
  }
}
