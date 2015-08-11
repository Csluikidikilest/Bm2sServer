using System.Collections.Generic;

namespace Bm2s.Services.POS.PointOfSale.Screen
{
  public class ScreensResponse
  {
    public ScreensResponse()
    {
      this.Screens = new List<Bm2s.Data.POS.BLL.PointOfSale.Screen>();
    }

    public List<Bm2s.Data.POS.BLL.PointOfSale.Screen> Screens { get; set; }
  }
}
