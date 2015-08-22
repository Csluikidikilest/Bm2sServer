﻿using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Services.Common.User.Module;
using Bm2s.Services.Common.User.User;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.User.UserModule
{
  public class UserModulesService : Service
  {
    public UserModulesResponse Get(UserModules request)
    {
      UserModulesResponse response = new UserModulesResponse();
      List<Bm2s.Data.Common.BLL.User.UserModule> items = new List<Data.Common.BLL.User.UserModule>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.UserModules.Where(item =>
          (request.GrantorId == 0 || item.GrantorId == request.GrantorId) &&
          (request.ModuleId == 0 || item.ModuleId == request.ModuleId) &&
          (request.UserId == 0 || item.UserId == request.UserId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.UserModules.Where(item => request.Ids.Contains(item.Id)));
      }

      response.UserModules.AddRange(from item in items
                                    select new Bm2s.Poco.Common.User.UserModule()
                                    {
                                      Granted = item.Granted,
                                      Grantor = new UsersService().Get(new Users() { Ids = new List<int>() { item.GrantorId} }).Users.FirstOrDefault(),
                                      Id = item.Id,
                                      Module = new ModulesService().Get(new Modules() { Ids = new List<int>() { item.ModuleId } }).Modules.FirstOrDefault(),
                                      User = new UsersService().Get(new Users() { Ids = new List<int>() { item.UserId } }).Users.FirstOrDefault()
                                    });

      return response;
    }

    public UserModulesResponse Post(UserModules request)
    {
      if (request.UserModule.Id > 0)
      {
        Bm2s.Data.Common.BLL.User.UserModule item = Datas.Instance.DataStorage.UserModules[request.UserModule.Id];
        item.Granted = request.UserModule.Granted;
        item.GrantorId = request.UserModule.Grantor.Id;
        item.ModuleId = request.UserModule.Module.Id;
        item.UserId = request.UserModule.User.Id;
        Datas.Instance.DataStorage.UserModules[request.UserModule.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.User.UserModule item = new Data.Common.BLL.User.UserModule()
        {
          Granted = request.UserModule.Granted,
          GrantorId = request.UserModule.Grantor.Id,
          ModuleId = request.UserModule.Module.Id,
          UserId = request.UserModule.User.Id
        };

        Datas.Instance.DataStorage.UserModules.Add(item);
        request.UserModule.Id = item.Id;
      }

      UserModulesResponse response = new UserModulesResponse();
      response.UserModules.Add(request.UserModule);
      return response;
    }
  }
}
