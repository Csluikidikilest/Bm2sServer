using System;
using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Trade.HeaderLine;
using Bm2s.Response.Common.Trade.Payment;
using Bm2s.Response.Common.Trade.Reconciliation;
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
          (request.PaymentId == 0 || item.PaymentId == request.PaymentId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Reconciliations.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Trade.Reconciliation()
                        {
                          Amount = item.Amount,
                          EndingDate = item.EndingDate,
                          HeaderLine = new HeaderLinesService().Get(new HeaderLines() { Ids = new List<int>() { item.HeaderLineId } }).HeaderLines.FirstOrDefault(),
                          Id = item.Id,
                          Payment = new PaymentsService().Get(new Payments() { Ids = new List<int>() { item.PaymentId } }).Payments.FirstOrDefault(),
                          StartingDate = item.StartingDate
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.Reconciliations.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.Reconciliations.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.Reconciliations.Count + (collection.Count() % response.Reconciliations.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public ReconciliationsResponse Post(Reconciliations request)
    {
      if (request.Reconciliation.Id > 0)
      {
        Bm2s.Data.Common.BLL.Trade.Reconciliation item = Datas.Instance.DataStorage.Reconciliations[request.Reconciliation.Id];
        item.Amount = request.Reconciliation.Amount;
        item.EndingDate = request.Reconciliation.EndingDate;
        item.HeaderLineId = request.Reconciliation.HeaderLine.Id;
        item.PaymentId = request.Reconciliation.Payment.Id;
        item.StartingDate = request.Reconciliation.StartingDate;
        Datas.Instance.DataStorage.Reconciliations[request.Reconciliation.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Trade.Reconciliation item = new Data.Common.BLL.Trade.Reconciliation()
        {
          Amount = request.Reconciliation.Amount,
          EndingDate = request.Reconciliation.EndingDate,
          HeaderLineId = request.Reconciliation.HeaderLine.Id,
          PaymentId = request.Reconciliation.Payment.Id,
          StartingDate = request.Reconciliation.StartingDate
        };

        Datas.Instance.DataStorage.Reconciliations.Add(item);
        request.Reconciliation.Id = item.Id;
      }

      ReconciliationsResponse response = new ReconciliationsResponse();
      response.Reconciliations.Add(request.Reconciliation);
      return response;
    }

    public ReconciliationsResponse Delete(Reconciliations request)
    {
      Bm2s.Data.Common.BLL.Trade.Reconciliation item = Datas.Instance.DataStorage.Reconciliations[request.Reconciliation.Id];
      item.EndingDate = DateTime.Now;

      ReconciliationsResponse response = new ReconciliationsResponse();
      response.Reconciliations.Add(request.Reconciliation);
      return response;
    }
  }
}
