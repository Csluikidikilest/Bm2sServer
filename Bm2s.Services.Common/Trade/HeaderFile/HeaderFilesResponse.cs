using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.Trade.HeaderFile
{
  public class HeaderFilesResponse
  {
    public HeaderFilesResponse()
    {
      this.HeaderFiles = new List<Bm2s.Data.Common.BLL.Trade.HeaderFile>();
    }

    public List<Bm2s.Data.Common.BLL.Trade.HeaderFile> HeaderFiles { get; set; }
  }
}
