using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Partner.PartnerFil
{
  [Route("/bm2s/partnerfiles", Verbs = "GET, POST")]
  [Route("/bm2s/partnerfiles/{Ids}", Verbs = "GET")]
  public class PartnerFiles
  {
    public PartnerFiles()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Partner.PartnerFile PartnerFile { get; set; }
  }
}
