﻿using System;
using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Partner.Partner;
using Bm2s.Response.Common.User.User;
using Bm2s.Services.Common.User.User;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Partner.Partner
{
  public class PartnersService : Service
  {
    public PartnersResponse Get(Partners request)
    {
      PartnersResponse response = new PartnersResponse();
      List<Bm2s.Data.Common.BLL.Partner.Partner> items = new List<Data.Common.BLL.Partner.Partner>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Partners.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.CompanyName) || item.CompanyName.ToLower().Contains(request.CompanyName.ToLower())) &&
          (!request.IsCustomer || item.IsCustomer) &&
          (!request.IsSupplier || item.IsSupplier) &&
          (request.UserId == 0 || item.UserId == request.UserId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Partners.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Partner.Partner()
                        {
                          Code = item.Code,
                          CompanyIdentifier = item.CompanyIdentifier,
                          CompanyName = item.CompanyName,
                          Email = item.Email,
                          EndingDate = item.EndingDate,
                          FaxNumber = item.FaxNumber,
                          Id = item.Id,
                          IsCustomer = item.IsCustomer,
                          IsSupplier = item.IsSupplier,
                          Observation = item.Observation,
                          PhoneNumber = item.PhoneNumber,
                          PriceMultiplier = Convert.ToDecimal(item.PriceMultiplier),
                          StartingDate = item.StartingDate,
                          User = new UsersService().Get(new Users() { Ids = new List<int>() { item.UserId } }).Users.FirstOrDefault(),
                          WebSite = item.WebSite
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.Partners.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.Partners.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.Partners.Count + (collection.Count() % response.Partners.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public PartnersResponse Post(Partners request)
    {
      if (request.Partner.Id > 0)
      {
        Bm2s.Data.Common.BLL.Partner.Partner item = Datas.Instance.DataStorage.Partners[request.Partner.Id];
        item.Code = request.Partner.Code;
        item.CompanyIdentifier = request.Partner.CompanyIdentifier;
        item.CompanyName = request.Partner.CompanyName;
        item.Email = request.Partner.Email;
        item.EndingDate = request.Partner.EndingDate;
        item.FaxNumber = request.Partner.FaxNumber;
        item.IsCustomer = request.Partner.IsCustomer;
        item.IsSupplier = request.Partner.IsSupplier;
        item.Observation = request.Partner.Observation;
        item.PhoneNumber = request.Partner.PhoneNumber;
        item.PriceMultiplier = Convert.ToDouble(request.Partner.PriceMultiplier);
        item.StartingDate = request.Partner.StartingDate;
        item.UserId = request.Partner.User.Id;
        item.WebSite = request.Partner.WebSite;
        Datas.Instance.DataStorage.Partners[request.Partner.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Partner.Partner item = new Data.Common.BLL.Partner.Partner()
        {
          Code = request.Partner.Code,
          CompanyIdentifier = request.Partner.CompanyIdentifier,
          CompanyName = request.Partner.CompanyName,
          Email = request.Partner.Email,
          EndingDate = request.Partner.EndingDate,
          FaxNumber = request.Partner.FaxNumber,
          IsCustomer = request.Partner.IsCustomer,
          IsSupplier = request.Partner.IsSupplier,
          Observation = request.Partner.Observation,
          PhoneNumber = request.Partner.PhoneNumber,
          PriceMultiplier = Convert.ToDouble(request.Partner.PriceMultiplier),
          StartingDate = request.Partner.StartingDate,
          UserId = request.Partner.User.Id,
          WebSite = request.Partner.WebSite
        };

        Datas.Instance.DataStorage.Partners.Add(item);
        request.Partner.Id = item.Id;
      }

      PartnersResponse response = new PartnersResponse();
      response.Partners.Add(request.Partner);
      return response;
    }

    public PartnersResponse Delete(Partners request)
    {
      Bm2s.Data.Common.BLL.Partner.Partner item = Datas.Instance.DataStorage.Partners[request.Partner.Id];
      item.EndingDate = DateTime.Now;
      Datas.Instance.DataStorage.Partners[item.Id] = item;

      PartnersResponse response = new PartnersResponse();
      response.Partners.Add(request.Partner);
      return response;
    }
  }
}
