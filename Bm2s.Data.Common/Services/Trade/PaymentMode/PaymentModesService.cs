﻿using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Trade.PaymentMode
{
  public class PaymentModesService : Service
  {
    public object Get(PaymentModes request)
    {
      PaymentModesResponse response = new PaymentModesResponse();

      if (!request.Ids.Any())
      {
        response.PaymentModes.AddRange(Datas.Instance.DataStorage.PaymentModes);
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