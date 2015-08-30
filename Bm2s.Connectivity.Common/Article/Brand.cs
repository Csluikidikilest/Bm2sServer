using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Article.Brand;

namespace Bm2s.Connectivity.Common.Article
{
  public class Brand : ClientBase
  {
    public Brand()
      : base()
    {
      this.Request = new Brands();
      this.Response = new BrandsResponse();
    }

    public Brands Request { get; set; }

    public BrandsResponse Response { get; set; }

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
