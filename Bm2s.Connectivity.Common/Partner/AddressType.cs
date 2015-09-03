using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Partner.AddressType;

namespace Bm2s.Connectivity.Common.Partner
{
  public class AddressType : ClientBase
  {
    public AddressType()
      : base()
    {
      this.Request = new AddressTypes();
      this.Response = new AddressTypesResponse();
    }

    public AddressTypes Request { get; set; }

    public AddressTypesResponse Response { get; set; }

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
