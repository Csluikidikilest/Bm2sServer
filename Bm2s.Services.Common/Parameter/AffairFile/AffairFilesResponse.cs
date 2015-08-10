using System.Collections.Generic;

namespace Bm2s.Services.Common.Parameter.AffairFile
{
  public class AffairFilesResponse
  {
    public AffairFilesResponse()
    {
      this.AffairFiles = new List<Bm2s.Data.Common.BLL.Parameter.AffairFile>();
    }

    public List<Bm2s.Data.Common.BLL.Parameter.AffairFile> AffairFiles { get; set; }
  }
}
