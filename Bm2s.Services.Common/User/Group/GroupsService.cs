﻿using System;
using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.User.Group;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.User.Group
{
  public class GroupsService : Service
  {
    public GroupsResponse Get(Groups request)
    {
      GroupsResponse response = new GroupsResponse();
      List<Bm2s.Data.Common.BLL.User.Group> items = new List<Data.Common.BLL.User.Group>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Groups.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower())) &&
          (!request.IsSystem || item.IsSystem) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Groups.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.User.Group()
                        {
                          Code = item.Code,
                          EndingDate = item.EndingDate,
                          Id = item.Id,
                          IsSystem = item.IsSystem,
                          Name = item.Name,
                          StartingDate = item.StartingDate
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.Groups.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.Groups.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.Groups.Count + (collection.Count() % response.Groups.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public GroupsResponse Post(Groups request)
    {
      if (request.Group.Id > 0)
      {
        Bm2s.Data.Common.BLL.User.Group item = Datas.Instance.DataStorage.Groups[request.Group.Id];
        item.Code = request.Group.Code;
        item.EndingDate = request.Group.EndingDate;
        item.IsSystem = request.Group.IsSystem;
        item.Name = request.Group.Name;
        item.StartingDate = request.Group.StartingDate;
        Datas.Instance.DataStorage.Groups[request.Group.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.User.Group item = new Data.Common.BLL.User.Group()
        {
          Code = request.Group.Code,
          EndingDate = request.Group.EndingDate,
          IsSystem = request.Group.IsSystem,
          Name = request.Group.Name,
          StartingDate = request.Group.StartingDate
        };

        Datas.Instance.DataStorage.Groups.Add(item);
        request.Group.Id = item.Id;
      }

      GroupsResponse response = new GroupsResponse();
      response.Groups.Add(request.Group);
      return response;
    }

    public GroupsResponse Delete(Groups request)
    {
      Bm2s.Data.Common.BLL.User.Group item = Datas.Instance.DataStorage.Groups[request.Group.Id];
      item.EndingDate = DateTime.Now;
      Datas.Instance.DataStorage.Groups[item.Id] = item;

      GroupsResponse response = new GroupsResponse();
      response.Groups.Add(request.Group);
      return response;
    }
  }
}
