using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Trade.Reconciliation
{
  public class ReconciliationsService : Service
  {
    public object Get(Reconciliations request)
    {
      ReconciliationsResponse response = new ReconciliationsResponse();

      if (!request.Ids.Any())
      {
        response.Reconciliations.AddRange(Datas.Instance.DataStorage.Reconciliations.Where(item =>
          (request.HeaderLineId == 0 || item.HeaderLineId == request.HeaderLineId) &&
          (request.PaymentId == 0 || item.PaymentId == request.PaymentId)
          ));
      }
      else
      {
        response.Reconciliations.AddRange(Datas.Instance.DataStorage.Reconciliations.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(Reconciliations request)
    {
      if (request.Reconciliation.Id > 0)
      {
        Datas.Instance.DataStorage.Reconciliations[request.Reconciliation.Id] = request.Reconciliation;
      }
      else
      {
        Datas.Instance.DataStorage.Reconciliations.Add(request.Reconciliation);
      }
      return request.Reconciliation;
    }
  }
}
