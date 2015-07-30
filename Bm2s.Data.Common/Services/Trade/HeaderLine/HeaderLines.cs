using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Trade.HeaderLine
{
  [Route("/bm2s/headerlines", Verbs = "GET, POST")]
  [Route("/bm2s/headerlines/{Ids}", Verbs = "GET")]
  public class HeaderLines : IReturn<HeaderLinesResponse>
  {
    public HeaderLines()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Trade.HeaderLine HeaderLine { get; set; }
  }
}
