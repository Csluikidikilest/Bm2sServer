using System.Collections.Generic;

namespace Bm2s.Response.Common.Parameter.Language
{
  public class LanguagesResponse : Response
  {
    public LanguagesResponse()
    {
      this.Languages = new List<Bm2s.Poco.Common.Parameter.Language>();
    }

    public List<Bm2s.Poco.Common.Parameter.Language> Languages { get; set; }
  }
}
