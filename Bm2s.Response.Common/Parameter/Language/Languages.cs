using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Parameter.Language
{
  [Route("/bm2s/languages", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/languages/{Ids}", Verbs = "GET")]
  public class Languages : Request, IReturn<LanguagesResponse>
  {
    public Languages()
    {
      this.Ids = new List<int>();
    }

    public string Code { get; set; }

    public string Name { get; set; }

    public Bm2s.Poco.Common.Parameter.Language Language { get; set; }
  }
}
