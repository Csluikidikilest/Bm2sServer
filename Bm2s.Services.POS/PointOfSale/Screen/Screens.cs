using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Services.POS.PointOfSale.Screen
{
  [Route("/bm2s/screens", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/screens/{Ids}", Verbs = "GET")]
  public class Screens
  {
    public Screens()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public Bm2s.Data.POS.BLL.PointOfSale.Screen Screen { get; set; }
  }
}
