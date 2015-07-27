using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Parameter.AffairFile
{
  public class AffairFilesResponse
  {
    public AffairFilesResponse()
    {
      this.AffairFiles = new List<BLL.Parameter.AffairFile>();
    }

    public List<BLL.Parameter.AffairFile> AffairFiles { get; set; }
  }
}
