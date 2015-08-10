using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Trade.PaymentMode
{
  public class PaymentModesService : Service
  {
    public object Get(PaymentModes request)
    {
      PaymentModesResponse response = new PaymentModesResponse();

      if (!request.Ids.Any())
      {
        response.PaymentModes.AddRange(Datas.Instance.DataStorage.PaymentModes.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower())) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        response.PaymentModes.AddRange(Datas.Instance.DataStorage.PaymentModes.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(PaymentModes request)
    {
      if (request.PaymentMode.Id > 0)
      {
        Datas.Instance.DataStorage.PaymentModes[request.PaymentMode.Id] = request.PaymentMode;
      }
      else
      {
        Datas.Instance.DataStorage.PaymentModes.Add(request.PaymentMode);
      }
      return request.PaymentMode;
    }
  }
}
