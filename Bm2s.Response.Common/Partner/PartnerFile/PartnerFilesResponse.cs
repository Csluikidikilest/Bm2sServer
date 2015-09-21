using System.Collections.Generic;

namespace Bm2s.Response.Common.Partner.PartnerFil
{
  public class PartnerFilesResponse : Response
  {
    public PartnerFilesResponse()
    {
      this.PartnerFiles = new List<Bm2s.Poco.Common.Partner.PartnerFile>();
    }

    public List<Bm2s.Poco.Common.Partner.PartnerFile> PartnerFiles { get; set; }
  }
}
