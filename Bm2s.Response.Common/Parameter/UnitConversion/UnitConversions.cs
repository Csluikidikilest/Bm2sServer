using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Parameter.UnitConversion
{
  [Route("/bm2s/unitconversions", Verbs = "GET, POST")]
  [Route("/bm2s/unitconversions/{Ids}", Verbs = "GET")]
  public class UnitConversions : IReturn<UnitConversionsResponse>
  {
    public UnitConversions()
    {
      this.Ids = new List<int>();
    }

    public int ChildId { get; set; }

    public List<int> Ids { get; set; }

    public int ParentId { get; set; }

    public Bm2s.Poco.Common.Parameter.UnitConversion UnitConversion { get; set; }
  }
}
