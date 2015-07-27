using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Trade.HeaderFreeReference
{
  public class HeaderFreeReferencesResponse
  {
    public HeaderFreeReferencesResponse()
    {
      this.HeaderFreeReferences = new List<BLL.Trade.HeaderFreeReference>();
    }

    public List<BLL.Trade.HeaderFreeReference> HeaderFreeReferences { get; set; }
  }
}
