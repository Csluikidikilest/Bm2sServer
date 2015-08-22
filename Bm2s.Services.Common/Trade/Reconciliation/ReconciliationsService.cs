﻿using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Services.Common.Trade.HeaderLine;
using Bm2s.Services.Common.Trade.Payment;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Trade.Reconciliation
{
  public class ReconciliationsService : Service
  {
    public ReconciliationsResponse Get(Reconciliations request)
    {
      ReconciliationsResponse response = new ReconciliationsResponse();
      List<Bm2s.Data.Common.BLL.Trade.Reconciliation> items = new List<Data.Common.BLL.Trade.Reconciliation>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Reconciliations.Where(item =>
          (request.HeaderLineId == 0 || item.HeaderLineId == request.HeaderLineId) &&
          (request.PaymentId == 0 || item.PaymentId == request.PaymentId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Reconciliations.Where(item => request.Ids.Contains(item.Id)));
      }

      response.Reconciliations.AddRange(from item in items
                                        select new Bm2s.Poco.Common.Trade.Reconciliation()
                                        {
                                          Amount = item.Amount,
                                          HeaderLine = new HeaderLinesService().Get(new HeaderLines() { Ids = new List<int>() { item.HeaderLineId} }).HeaderLines.FirstOrDefault(),
                                          Id = item.Id,
                                          Payment = new PaymentsService().Get(new Payments() { Ids = new List<int>() { item.PaymentId} }).Payments.FirstOrDefault()
                                        });

      return response;
    }

    public ReconciliationsResponse Post(Reconciliations request)
    {
      if (request.Reconciliation.Id > 0)
      {
        Bm2s.Data.Common.BLL.Trade.Reconciliation item = Datas.Instance.DataStorage.Reconciliations[request.Reconciliation.Id];
        item.Amount = request.Reconciliation.Amount;
        item.HeaderLineId = request.Reconciliation.HeaderLine.Id;
        item.PaymentId = request.Reconciliation.Payment.Id;
        Datas.Instance.DataStorage.Reconciliations[request.Reconciliation.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Trade.Reconciliation item = new Data.Common.BLL.Trade.Reconciliation()
        {
          Amount = request.Reconciliation.Amount,
          HeaderLineId = request.Reconciliation.HeaderLine.Id,
          PaymentId = request.Reconciliation.Payment.Id
        };

        Datas.Instance.DataStorage.Reconciliations.Add(item);
        request.Reconciliation.Id = item.Id;
      }

      ReconciliationsResponse response = new ReconciliationsResponse();
      response.Reconciliations.Add(request.Reconciliation);
      return response;
    }
  }
}
