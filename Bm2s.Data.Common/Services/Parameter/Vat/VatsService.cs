using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Parameter.Vat
{
  public class VatsService : Service
  {
    public object Get(Vats request)
    {
      VatsResponse response = new VatsResponse();

      if (!request.Ids.Any())
      {
        response.Vats.AddRange(Datas.Instance.DataStorage.Vats.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.Contains(request.Code)) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        response.Vats.AddRange(Datas.Instance.DataStorage.Vats.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(Vats request)
    {
      if (request.Vat.Id > 0)
      {
        Datas.Instance.DataStorage.Vats[request.Vat.Id] = request.Vat;
      }
      else
      {
        Datas.Instance.DataStorage.Vats.Add(request.Vat);
      }
      return request.Vat;
    }
  }
}
