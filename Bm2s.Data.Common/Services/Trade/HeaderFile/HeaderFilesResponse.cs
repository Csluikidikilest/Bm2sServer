using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Trade.HeaderFile
{
  public class HeaderFilesResponse
  {
    public HeaderFilesResponse()
    {
      this.HeaderFiles = new List<BLL.Trade.HeaderFile>();
    }

    public List<BLL.Trade.HeaderFile> HeaderFiles { get; set; }
  }
}
