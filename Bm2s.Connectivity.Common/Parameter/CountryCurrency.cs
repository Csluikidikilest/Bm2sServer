using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Parameter.CountryCurrency;

namespace Bm2s.Connectivity.Common.Parameter
{
  public class CountryCurrency : ClientBase
  {
    public CountryCurrency()
      : base()
    {
      this.Request = new CountryCurrencies();
      this.Response = new CountryCurrenciesResponse();
    }

    public CountryCurrencies Request { get; set; }

    public CountryCurrenciesResponse Response { get; set; }

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
