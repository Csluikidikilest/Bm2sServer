using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Parameter.Language;

namespace Bm2s.Connectivity.Common.Parameter
{
  public class Language : ClientBase
  {
    public Language():base()
    {
      this.Request = new Languages();
      this.Response = new LanguagesResponse();
    }

    public Languages Request { get; set; }

    public LanguagesResponse Response { get; set; }

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
