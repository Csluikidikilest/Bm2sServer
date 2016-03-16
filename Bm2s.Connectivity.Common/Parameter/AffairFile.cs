using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Parameter.AffairFile;

namespace Bm2s.Connectivity.Common.Parameter
{
  public class AffairFile : ClientBase
  {
    public AffairFile()
      : base()
    {
      this.Request = new AffairFiles();
      this.Response = new AffairFilesResponse();
    }

    public AffairFiles Request { get; set; }

    public AffairFilesResponse Response { get; set; }

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

    public void Delete()
    {
      this.Response = this.ConnectorHelper.Delete(this.Request);
      this.IsFilled = true;
    }

    protected override void LoadFromNameValueCollection(System.Collections.Specialized.NameValueCollection parameters)
    {
      this.Request.LoadFromNameValueCollection(parameters);
    }
  }
}
