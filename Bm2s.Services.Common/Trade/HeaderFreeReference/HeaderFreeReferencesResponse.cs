using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.Trade.HeaderFreeReference
{
  public class HeaderFreeReferencesResponse
  {
    public HeaderFreeReferencesResponse()
    {
      this.HeaderFreeReferences = new List<Bm2s.Data.Common.BLL.Trade.HeaderFreeReference>();
    }

    public List<Bm2s.Data.Common.BLL.Trade.HeaderFreeReference> HeaderFreeReferences { get; set; }
  }
}
