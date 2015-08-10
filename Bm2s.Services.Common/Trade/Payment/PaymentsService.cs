using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Trade.Payment
{
  public class PaymentsService : Service
  {
    public object Get(Payments request)
    {
      PaymentsResponse response = new PaymentsResponse();

      if (!request.Ids.Any())
      {
        response.Payments.AddRange(Datas.Instance.DataStorage.Payments.Where(item =>
          (!request.Date.HasValue || item.Date >= request.Date) &&
          (request.PartnerId == 0 || item.PartnerId == request.PartnerId) &&
          (request.PaymentModeId == 0 || item.PaymentModeId == request.PaymentModeId) &&
          (request.UnitId == 0 || item.UnitId == request.UnitId)
          ));
      }
      else
      {
        response.Payments.AddRange(Datas.Instance.DataStorage.Payments.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(Payments request)
    {
      if (request.Payment.Id > 0)
      {
        Datas.Instance.DataStorage.Payments[request.Payment.Id] = request.Payment;
      }
      else
      {
        Datas.Instance.DataStorage.Payments.Add(request.Payment);
      }
      return request.Payment;
    }
  }
}
