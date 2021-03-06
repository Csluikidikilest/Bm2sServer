﻿using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Partner.Address;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Partner.Address
{
  class AddressesService : Service
  {
    public AddressesResponse Get(Addresses request)
    {
      AddressesResponse response = new AddressesResponse();
      List<Bm2s.Data.Common.BLL.Partner.Address> items = new List<Data.Common.BLL.Partner.Address>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Addresses);
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Addresses.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Partner.Address()
                        {
                          CountryName = item.CountryName,
                          Id = item.Id,
                          TownName = item.TownName,
                          TownZipCode = item.TownZipCode
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.Addresses.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.Addresses.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.Addresses.Count + (collection.Count() % response.Addresses.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public AddressesResponse Post(Addresses request)
    {
      if (request.Address.Id > 0)
      {
        Bm2s.Data.Common.BLL.Partner.Address item = Datas.Instance.DataStorage.Addresses[request.Address.Id];
        item.CountryName = request.Address.CountryName;
        item.TownName = request.Address.TownName;
        item.TownZipCode = request.Address.TownZipCode;
        Datas.Instance.DataStorage.Addresses[request.Address.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Partner.Address item = new Data.Common.BLL.Partner.Address()
        {
          CountryName = request.Address.CountryName,
          TownName = request.Address.TownName,
          TownZipCode = request.Address.TownZipCode
        };

        Datas.Instance.DataStorage.Addresses.Add(item);
        request.Address.Id = item.Id;
      }

      AddressesResponse response = new AddressesResponse();
      response.Addresses.Add(request.Address);
      return response;
    }

    public AddressesResponse Delete(Addresses request)
    {
      Bm2s.Data.Common.BLL.Partner.Address item = Datas.Instance.DataStorage.Addresses[request.Address.Id];
      Datas.Instance.DataStorage.Addresses.Remove(item);

      AddressesResponse response = new AddressesResponse();
      response.Addresses.Add(request.Address);
      return response;
    }
  }
}
