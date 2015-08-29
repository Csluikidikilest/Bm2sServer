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
      List<Bm2s.Data.Common.BLL.Trade.PaymentMode> items = new List<Data.Common.BLL.Trade.PaymentMode>();
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

      response.PaymentModes.AddRange((from item in items
                                     select new Bm2s.Poco.Common.Trade.PaymentMode()
                                     {
                                       Code = item.Code,
                                       EndingDate = item.EndingDate,
                                       Id = item.Id,
                                       Name = item.Name,
                                       StartingDate = item.StartingDate
                                     }).AsQueryable().OrderBy(request.Order, request.AscendingOrder).Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));

      return response;
    }

    public PaymentModesResponse Post(PaymentModes request)
    {
      if (request.PaymentMode.Id > 0)
      {
        Bm2s.Data.Common.BLL.Trade.PaymentMode item = Datas.Instance.DataStorage.PaymentModes[request.PaymentMode.Id];
        item.Code = request.PaymentMode.Code;
        item.EndingDate = request.PaymentMode.EndingDate;
        item.Name = request.PaymentMode.Name;
        item.StartingDate = request.PaymentMode.StartingDate;
        Datas.Instance.DataStorage.PaymentModes[request.PaymentMode.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Trade.PaymentMode item = new Data.Common.BLL.Trade.PaymentMode()
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
  }
}
