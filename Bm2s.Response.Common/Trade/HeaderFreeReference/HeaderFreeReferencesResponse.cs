using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Response.Common.Trade.HeaderFreeReference
{
  public class HeaderFreeReferencesResponse
  {
    public HeaderFreeReferencesResponse()
    {
      this.HeaderFreeReferences = new List<Bm2s.Poco.Common.Trade.HeaderFreeReference>();
    }

    public List<Bm2s.Poco.Common.Trade.HeaderFreeReference> HeaderFreeReferences { get; set; }
  }
}
