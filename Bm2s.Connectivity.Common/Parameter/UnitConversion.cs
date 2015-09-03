using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Parameter.UnitConversion;

namespace Bm2s.Connectivity.Common.Parameter
{
  public class UnitConversion : ClientBase
  {
    public UnitConversion()
      : base()
    {
      this.Request = new UnitConversions();
      this.Response = new UnitConversionsResponse();
    }

    public UnitConversions Request { get; set; }

    public UnitConversionsResponse Response { get; set; }

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
