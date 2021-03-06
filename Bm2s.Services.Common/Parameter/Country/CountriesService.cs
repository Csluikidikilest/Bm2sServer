﻿using System;
using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Parameter.Country;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.Country
{
  public class CountriesService : Service
  {
    public CountriesResponse Get(Countries request)
    {
      CountriesResponse response = new CountriesResponse();
      List<Bm2s.Data.Common.BLL.Parameter.Country> items = new List<Data.Common.BLL.Parameter.Country>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Countries.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower())) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Countries.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Parameter.Country()
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
        response.Countries.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.Countries.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.Countries.Count + (collection.Count() % response.Countries.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public CountriesResponse Post(Countries request)
    {
      if (request.Country.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.Country item = Datas.Instance.DataStorage.Countries[request.Country.Id];
        item.Code = request.Country.Code;
        item.EndingDate = request.Country.EndingDate;
        item.Name = request.Country.Name;
        item.StartingDate = request.Country.StartingDate;
        Datas.Instance.DataStorage.Countries[request.Country.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.Country item = new Data.Common.BLL.Parameter.Country()
        {
          Code = request.Country.Code,
          EndingDate = request.Country.EndingDate,
          Name = request.Country.Name,
          StartingDate = request.Country.StartingDate
        };

        Datas.Instance.DataStorage.Countries.Add(item);
        request.Country.Id = item.Id;
      }

      CountriesResponse response = new CountriesResponse();
      response.Countries.Add(request.Country);
      return response;
    }

    public CountriesResponse Delete(Countries request)
    {
      Bm2s.Data.Common.BLL.Parameter.Country item = Datas.Instance.DataStorage.Countries[request.Country.Id];
      item.EndingDate = DateTime.Now;
      Datas.Instance.DataStorage.Countries[item.Id] = item;

      CountriesResponse response = new CountriesResponse();
      response.Countries.Add(request.Country);
      return response;
    }
  }
}
