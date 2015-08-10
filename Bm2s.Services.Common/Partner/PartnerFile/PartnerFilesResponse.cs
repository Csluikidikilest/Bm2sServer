using System.Collections.Generic;

namespace Bm2s.Services.Common.Partner.PartnerFil
{
  class PartnerFilesResponse
  {
    public PartnerFilesResponse()
    {
      this.PartnerFiles = new List<Bm2s.Data.Common.BLL.Partner.PartnerFile>();
    }

    public List<Bm2s.Data.Common.BLL.Partner.PartnerFile> PartnerFiles { get; set; }
  }
}
