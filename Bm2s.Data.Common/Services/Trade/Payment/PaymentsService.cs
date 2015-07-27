using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Trade.Payment
{
  public class PaymentsService : Service
  {
    public object Get(Payments request)
    {
      PaymentsResponse response = new PaymentsResponse();

      if (!request.Ids.Any())
      {
        response.Payments.AddRange(Datas.Instance.DataStorage.Payments);
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
