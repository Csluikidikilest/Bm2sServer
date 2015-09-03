using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Article.Subscription;

namespace Bm2s.Connectivity.Common.Article
{
  public class Subscription:ClientBase
  {
    public Subscription()
      : base()
    {
      this.Request = new Subscriptions();
      this.Response = new SubscriptionsResponse();
    }

    public Subscriptions Request { get; set; }

    public SubscriptionsResponse Response { get; set; }

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
