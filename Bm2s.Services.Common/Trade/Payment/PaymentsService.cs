using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Parameter.Unit;
using Bm2s.Response.Common.Partner.Partner;
using Bm2s.Response.Common.Trade.Payment;
using Bm2s.Response.Common.Trade.PaymentMode;
using Bm2s.Services.Common.Parameter.Unit;
using Bm2s.Services.Common.Partner.Partner;
using Bm2s.Services.Common.Trade.PaymentMode;
using ServiceStack.ServiceInterface;
using System;

namespace Bm2s.Services.Common.Trade.Payment
{
  public class PaymentsService : Service
  {
    public PaymentsResponse Get(Payments request)
    {
      PaymentsResponse response = new PaymentsResponse();
      List<Bm2s.Data.Common.BLL.Trade.Paym> items = new List<Data.Common.BLL.Trade.Paym>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Payments.Where(item =>
          (!request.Date.HasValue || item.Date >= request.Date) &&
          (request.PartnerId == 0 || item.PartId == request.PartnerId) &&
          (request.PaymentModeId == 0 || item.PamoId == request.PaymentModeId) &&
          (request.UnitId == 0 || item.UnitId == request.UnitId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Payments.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Trade.Payment()
                        {
                          Amount = Convert.ToDecimal(item.Amount),
                          Date = item.Date,
                          Id = item.Id,
                          Reference = item.Reference,
                          Partner = new PartnersService().Get(new Partners() { Ids = new List<int>() { item.PartId } }).Partners.FirstOrDefault(),
                          PaymentMode = new PaymentModesService().Get(new PaymentModes() { Ids = new List<int>() { item.PamoId } }).PaymentModes.FirstOrDefault(),
                          Unit = new UnitsService().Get(new Units() { Ids = new List<int>() { item.UnitId } }).Units.FirstOrDefault()
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.Payments.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.Payments.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.Payments.Count + (collection.Count() % response.Payments.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public PaymentsResponse Post(Payments request)
    {
      if (request.Payment.Id > 0)
      {
        Bm2s.Data.Common.BLL.Trade.Paym item = Datas.Instance.DataStorage.Payments[request.Payment.Id];
        item.Amount = Convert.ToDouble(request.Payment.Amount);
        item.Date = request.Payment.Date;
        item.Reference = request.Payment.Reference;
        item.PartId = request.Payment.Partner.Id;
        item.PamoId = request.Payment.PaymentMode.Id;
        item.UnitId = request.Payment.Unit.Id;
        Datas.Instance.DataStorage.Payments[request.Payment.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Trade.Paym item = new Data.Common.BLL.Trade.Paym()
        {
          Amount = Convert.ToDouble(request.Payment.Amount),
          Date = request.Payment.Date,
          Reference = request.Payment.Reference,
          PartId = request.Payment.Partner.Id,
          PamoId = request.Payment.PaymentMode.Id,
          UnitId = request.Payment.Unit.Id
        };

        Datas.Instance.DataStorage.Payments.Add(item);
        request.Payment.Id = item.Id;
      }

      PaymentsResponse response = new PaymentsResponse();
      response.Payments.Add(request.Payment);
      return response;
    }

    public PaymentsResponse Delete(Payments request)
    {
      Bm2s.Data.Common.BLL.Trade.Paym item = Datas.Instance.DataStorage.Payments[request.Payment.Id];
      Datas.Instance.DataStorage.Payments.Remove(item);

      PaymentsResponse response = new PaymentsResponse();
      response.Payments.Add(request.Payment);
      return response;
    }
  }
}
