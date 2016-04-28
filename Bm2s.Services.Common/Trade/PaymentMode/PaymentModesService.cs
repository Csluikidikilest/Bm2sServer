using System;
using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Trade.PaymentMode;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Trade.PaymentMode
{
  public class PaymentModesService : Service
  {
    public PaymentModesResponse Get(PaymentModes request)
    {
      PaymentModesResponse response = new PaymentModesResponse();
      List<Bm2s.Data.Common.BLL.Trade.Pamo> items = new List<Data.Common.BLL.Trade.Pamo>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.PaymentModes.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower())) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.PaymentModes.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Trade.PaymentMode()
                        {
                          Code = item.Code,
                          EndingDate = item.EndingDate,
                          Id = item.Id,
                          Name = item.Name,
                          StartingDate = item.StartingDate
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.PaymentModes.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.PaymentModes.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.PaymentModes.Count + (collection.Count() % response.PaymentModes.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public PaymentModesResponse Post(PaymentModes request)
    {
      if (request.PaymentMode.Id > 0)
      {
        Bm2s.Data.Common.BLL.Trade.Pamo item = Datas.Instance.DataStorage.PaymentModes[request.PaymentMode.Id];
        item.Code = request.PaymentMode.Code;
        item.EndingDate = request.PaymentMode.EndingDate;
        item.Name = request.PaymentMode.Name;
        item.StartingDate = request.PaymentMode.StartingDate;
        Datas.Instance.DataStorage.PaymentModes[request.PaymentMode.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Trade.Pamo item = new Data.Common.BLL.Trade.Pamo()
        {
          Code = request.PaymentMode.Code,
          EndingDate = request.PaymentMode.EndingDate,
          Name = request.PaymentMode.Name,
          StartingDate = request.PaymentMode.StartingDate
        };

        Datas.Instance.DataStorage.PaymentModes.Add(item);
        request.PaymentMode.Id = item.Id;
      }

      PaymentModesResponse response = new PaymentModesResponse();
      response.PaymentModes.Add(request.PaymentMode);
      return response;
    }

    public PaymentModesResponse Delete(PaymentModes request)
    {
      Bm2s.Data.Common.BLL.Trade.Pamo item = Datas.Instance.DataStorage.PaymentModes[request.PaymentMode.Id];
      item.EndingDate = DateTime.Now;
      Datas.Instance.DataStorage.PaymentModes[item.Id] = item;

      PaymentModesResponse response = new PaymentModesResponse();
      response.PaymentModes.Add(request.PaymentMode);
      return response;
    }
  }
}
