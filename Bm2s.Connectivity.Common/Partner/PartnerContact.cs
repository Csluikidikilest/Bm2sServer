using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Partner.PartnerContact;

namespace Bm2s.Connectivity.Common.Partner
{
  public class PartnerContact : ClientBase
  {
    public PartnerContact()
      : base()
    {
      this.Request = new PartnerContacts();
      this.Response = new PartnerContactsResponse();
    }

    public PartnerContacts Request { get; set; }

    public PartnerContactsResponse Response { get; set; }

    public void Get()
    {
      this.Response = this.ConnectorHelper.Get(this.Request);
      this.IsFilled = true;
    }

    public void Post()
    {
      this.Response = this.ConnectorHelper.Post(this.Request);
      this.IsFilled = true;
    }

    protected override void LoadFromNameValueCollection(System.Collections.Specialized.NameValueCollection parameters)
    {
      this.Request.LoadFromNameValueCollection(parameters);
    }
  }
}
