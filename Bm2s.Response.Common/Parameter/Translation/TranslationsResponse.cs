using System.Collections.Generic;

namespace Bm2s.Response.Common.Parameter.Translation
{
  public class TranslationsResponse : Response
  {
    public TranslationsResponse()
    {
      this.Translations = new List<Bm2s.Poco.Common.Parameter.Translation>();
    }

    public List<Bm2s.Poco.Common.Parameter.Translation> Translations { get; set; }
  }
}
