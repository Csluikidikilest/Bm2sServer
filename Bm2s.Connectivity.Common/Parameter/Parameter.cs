using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Parameter.Parameter;

namespace Bm2s.Connectivity.Common.Parameter
{
  public class Parameter : ClientBase
  {
    public Parameter()
      : base()
    {
      this.Request = new Parameters();
      this.Response = new ParametersResponse();
    }

    public Parameters Request { get; set; }

    public ParametersResponse Response { get; set; }

    public void Get()
    {
      this.Response = this.ConnectorHelper.Get(this.Request);
      this.IsFilled = true;
    }

    protected override void LoadFromNameValueCollection(System.Collections.Specialized.NameValueCollection parameters)
    {
      this.Request.LoadFromNameValueCollection(parameters);
    }
  }
}
