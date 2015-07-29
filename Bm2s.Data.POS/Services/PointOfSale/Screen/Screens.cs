using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.POS.Services.PointOfSale.Screen
{
  [Route("/bm2s/screens", Verbs = "GET, POST")]
  [Route("/bm2s/screens/{Ids}", Verbs = "GET")]
  public class Screens
  {
    public Screens()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.PointOfSale.Screen Screen { get; set; }
  }
}
