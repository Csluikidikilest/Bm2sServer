﻿using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Parameter.Town
{
  public class TownsService : Service
  {
    public object Get(Towns request)
    {
      TownsResponse response = new TownsResponse();

      if (!request.Ids.Any())
      {
        response.Towns.AddRange(Datas.Instance.DataStorage.Towns);
      }
      else
      {
        response.Towns.AddRange(Datas.Instance.DataStorage.Towns.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(Towns request)
    {
      if (request.Town.Id > 0)
      {
        Datas.Instance.DataStorage.Towns[request.Town.Id] = request.Town;
      }
      else
      {
        Datas.Instance.DataStorage.Towns.Add(request.Town);
      }
      return request.Town;
    }
  }
}
