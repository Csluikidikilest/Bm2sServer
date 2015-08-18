﻿using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Services.Common.Parameter.Activity;
using Bm2s.Services.Common.User.User;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.Affair
{
  public class AffairsService : Service
  {
    public AffairsResponse Get(Affairs request)
    {
      AffairsResponse response = new AffairsResponse();
      List<Bm2s.Data.Common.BLL.Parameter.Affair> items = new List<Data.Common.BLL.Parameter.Affair>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Affairs.Where(item =>
          (request.ActivityId == 0 || item.ActivityId == request.ActivityId) &&
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower())) &&
          (request.UserId == 0 || item.UserId == request.UserId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Affairs.Where(item => request.Ids.Contains(item.Id)));
      }

      response.Affairs.AddRange(from item in items
                                select new Bm2s.Poco.Common.Parameter.Affair()
                                {
                                  Activity = new ActivitiesService().Get(new Activities() { Ids = new List<int>() { item.ActivityId } }).Activities.FirstOrDefault(),
                                  Code = item.Code,
                                  Description = item.Description,
                                  Id = item.Id,
                                  Name = item.Name,
                                  User = new UsersService().Get(new Users() { Ids = new List<int>() { item.UserId } }).Users.FirstOrDefault()
                                });

      return response;
    }

    public Bm2s.Poco.Common.Parameter.Affair Post(Affairs request)
    {
      if (request.Affair.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.Affair item = Datas.Instance.DataStorage.Affairs[request.Affair.Id];
        item.ActivityId = request.Affair.Activity.Id;
        item.Code = request.Affair.Code;
        item.Description = request.Affair.Description;
        item.Name = request.Affair.Name;
        item.UserId = request.Affair.User.Id;
        Datas.Instance.DataStorage.Affairs[request.Affair.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.Affair item = new Data.Common.BLL.Parameter.Affair()
        {
          ActivityId = request.Affair.Activity.Id,
          Code = request.Affair.Code,
          Description = request.Affair.Description,
          Name = request.Affair.Name,
          UserId = request.Affair.User.Id
        };

        Datas.Instance.DataStorage.Affairs.Add(item);
        request.Affair.Id = item.Id;
      }

      return request.Affair;
    }
  }
}