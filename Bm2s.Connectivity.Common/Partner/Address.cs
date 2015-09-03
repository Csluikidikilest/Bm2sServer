using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Partner.Address;

namespace Bm2s.Connectivity.Common.Partner
{
  public class Address : ClientBase
  {
    public Address()
      : base()
    {
      this.Request = new Addresses();
      this.Response = new AddressesResponse();
    }

    public Addresses Request { get; set; }

    public AddressesResponse Response { get; set; }

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
