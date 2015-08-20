﻿using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.User.Module
{
  public class ModulesService : Service
  {
    public ModulesResponse Get(Modules request)
    {
      ModulesResponse response = new ModulesResponse();
      List<Bm2s.Data.Common.BLL.User.Module> items = new List<Data.Common.BLL.User.Module>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Modules.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower()))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Modules.Where(item => request.Ids.Contains(item.Id)));
      }

      response.Modules.AddRange(from item in items
                                select new Bm2s.Poco.Common.User.Module()
                                {
                                  Code = item.Code,
                                  Description = item.Description,
                                  Id = item.Id,
                                  Name = item.Name
                                });

      return response;
    }

    public Bm2s.Poco.Common.User.Module Post(Modules request)
    {
      if (request.Module.Id > 0)
      {
        Bm2s.Data.Common.BLL.User.Module item = Datas.Instance.DataStorage.Modules[request.Module.Id];
        item.Code = request.Module.Code;
        item.Description = request.Module.Description;
        item.Id = request.Module.Id;
        item.Name = request.Module.Name;
        Datas.Instance.DataStorage.Modules[request.Module.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.User.Module item = new Data.Common.BLL.User.Module()
        {
          Code = request.Module.Code,
          Description = request.Module.Description,
          Id = request.Module.Id,
          Name = request.Module.Name
        };

        Datas.Instance.DataStorage.Modules.Add(item);
        request.Module.Id = item.Id;
      }

      return request.Module;
    }
  }
}
