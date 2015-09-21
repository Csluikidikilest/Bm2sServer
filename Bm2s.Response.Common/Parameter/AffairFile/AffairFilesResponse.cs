using System.Collections.Generic;

namespace Bm2s.Response.Common.Parameter.AffairFile
{
  public class AffairFilesResponse : Response
  {
    public AffairFilesResponse()
    {
      this.AffairFiles = new List<Bm2s.Poco.Common.Parameter.AffairFile>();
    }

    public List<Bm2s.Poco.Common.Parameter.AffairFile> AffairFiles { get; set; }
  }
}
