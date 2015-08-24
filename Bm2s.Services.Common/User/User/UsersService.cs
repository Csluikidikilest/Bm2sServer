﻿using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.User.User;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.User.User
{
  public class UsersService : Service
  {
    public UsersResponse Get(Users request)
    {
      UsersResponse response = new UsersResponse();
      List<Bm2s.Data.Common.BLL.User.User> items = new List<Data.Common.BLL.User.User>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Users.Where(item =>
          (string.IsNullOrWhiteSpace(request.FirstName) || item.FirstName.ToLower().Contains(request.FirstName.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.LastName) || item.LastName.ToLower().Contains(request.LastName.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Login) || item.Login.ToLower().Contains(request.Login.ToLower())) &&
          (!request.IsAdministrator || item.IsAdministrator) &&
          (!request.IsAnonymous || item.IsAnonymous) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Users.Where(item => request.Ids.Contains(item.Id)));
      }

      response.Users.AddRange(from item in items
                              select new Bm2s.Poco.Common.User.User()
                              {
                                EndingDate = item.EndingDate,
                                FirstName = item.FirstName,
                                Id = item.Id,
                                IsAdministrator = item.IsAdministrator,
                                IsAnonymous = item.IsAnonymous,
                                LastName = item.LastName,
                                Login = item.Login,
                                Password = item.Password,
                                StartingDate = item.StartingDate
                              });

      return response;
    }

    public UsersResponse Post(Users request)
    {
      if (request.User.Id > 0)
      {
        Bm2s.Data.Common.BLL.User.User item = Datas.Instance.DataStorage.Users[request.User.Id];
        item.EndingDate = request.User.EndingDate;
        item.FirstName = request.User.FirstName;
        item.IsAdministrator = request.User.IsAdministrator;
        item.IsAnonymous = request.User.IsAnonymous;
        item.LastName = request.User.LastName;
        item.Login = request.User.Login;
        item.Password = request.User.Password;
        item.StartingDate = request.User.StartingDate;
        Datas.Instance.DataStorage.Users[request.User.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.User.User item = new Data.Common.BLL.User.User()
        {
          EndingDate = request.User.EndingDate,
          FirstName = request.User.FirstName,
          IsAdministrator = request.User.IsAdministrator,
          IsAnonymous = request.User.IsAnonymous,
          LastName = request.User.LastName,
          Login = request.User.Login,
          Password = request.User.Password,
          StartingDate = request.User.StartingDate
        };

        Datas.Instance.DataStorage.Users.Add(item);
        request.User.Id = item.Id;
      }

      UsersResponse response = new UsersResponse();
      response.Users.Add(request.User);
      return response;
    }
  }
}
