using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Parameter.Translation
{
  [Route("/bm2s/translations", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/translations/{Ids}", Verbs = "GET")]
  public class Translations : Request, IReturn<TranslationsResponse>
  {
    public Translations()
    {
      this.Ids = new List<int>();
    }

    public string Application { get; set; }

    public int LanguageId { get; set; }

    public string Screen { get; set; }

    public string Key { get; set; }

    public Bm2s.Poco.Common.Parameter.Translation Translation { get; set; }
  }
}
