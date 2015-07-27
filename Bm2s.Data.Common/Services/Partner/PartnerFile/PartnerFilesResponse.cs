using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Partner.PartnerFil
{
  class PartnerFilesResponse
  {
    public PartnerFilesResponse()
    {
      this.PartnerFiles = new List<BLL.Partner.PartnerFile>();
    }

    public List<BLL.Partner.PartnerFile> PartnerFiles { get; set; }
  }
}
