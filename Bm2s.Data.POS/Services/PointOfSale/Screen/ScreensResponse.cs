using System.Collections.Generic;

namespace Bm2s.Data.POS.Services.PointOfSale.Screen
{
  public class ScreensResponse
  {
    public ScreensResponse()
    {
      this.Screens = new List<BLL.PointOfSale.Screen>();
    }

    public List<BLL.PointOfSale.Screen> Screens { get; set; }
  }
}
