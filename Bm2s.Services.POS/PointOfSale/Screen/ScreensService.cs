using System.Linq;
using Bm2s.Data.POS.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.POS.PointOfSale.Screen
{
  public class ScreensService : Service
  {
    public object Get(Screens request)
    {
      ScreensResponse response = new ScreensResponse();

      if (!request.Ids.Any())
      {
        response.Screens.AddRange(Datas.Instance.DataStorage.Screens);
      }
      else
      {
        response.Screens.AddRange(Datas.Instance.DataStorage.Screens.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(Screens request)
    {
      if (request.Screen.Id > 0)
      {
        Datas.Instance.DataStorage.Screens[request.Screen.Id] = request.Screen;
      }
      else
      {
        Datas.Instance.DataStorage.Screens.Add(request.Screen);
      }
      return request.Screen;
    }
  }
}
