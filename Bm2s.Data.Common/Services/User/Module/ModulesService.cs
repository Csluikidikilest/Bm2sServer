﻿using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.User.Module
{
  public class ModulesService : Service
  {
    public object Get(Modules request)
    {
      ModulesResponse response = new ModulesResponse();

      if (!request.Ids.Any())
      {
        response.Modules.AddRange(Datas.Instance.DataStorage.Modules);
      }
      else
      {
        response.Modules.AddRange(Datas.Instance.DataStorage.Modules.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(Modules request)
    {
      if (request.Module.Id > 0)
      {
        Datas.Instance.DataStorage.Modules[request.Module.Id] = request.Module;
      }
      else
      {
        Datas.Instance.DataStorage.Modules.Add(request.Module);
      }
      return request.Module;
    }
  }
}