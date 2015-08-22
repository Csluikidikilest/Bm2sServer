using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Connectivity.Utils;

namespace Bm2s.Connectivity.Common.Article
{
  public class Article : Connector
  {
    public Article()
      : base()
    {
      this.Poco = new Poco.Common.Article.Article();
    }

    public Bm2s.Poco.Common.Article.Article Poco { get; protected set; }

    protected override void LoadFromNameValueCollection(System.Collections.Specialized.NameValueCollection param)
    {
    }
  }
}
