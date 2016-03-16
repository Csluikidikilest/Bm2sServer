using System;
using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Partner.Partner;
using Bm2s.Response.Common.Partner.PartnerContact;
using Bm2s.Services.Common.Partner.Partner;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Partner.PartnerContact
{
  class PartnerContactsService : Service
  {
    public PartnerContactsResponse Get(PartnerContacts request)
    {
      PartnerContactsResponse response = new PartnerContactsResponse();
      List<Bm2s.Data.Common.BLL.Partner.PartnerContact> items = new List<Data.Common.BLL.Partner.PartnerContact>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.PartnerContacts.Where(item =>
          (string.IsNullOrWhiteSpace(request.Email) || item.Email.ToLower().Contains(request.Email.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.FaxNumber) || item.FaxNumber.ToLower().Contains(request.FaxNumber.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.FirstName) || item.FirstName.ToLower().Contains(request.FirstName.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Function) || item.Function.ToLower().Contains(request.Function.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.LastName) || item.LastName.ToLower().Contains(request.LastName.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.MobilePhoneNumber) || item.MobilePhoneNumber.ToLower().Contains(request.MobilePhoneNumber.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.PhoneNumber) || item.PhoneNumber.ToLower().Contains(request.PhoneNumber.ToLower())) &&
          (request.PartnerId == 0 || item.PartnerId == request.PartnerId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.PartnerContacts.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Partner.PartnerContact()
                        {
                          Email = item.Email,
                          EndingDate = item.EndingDate,
                          FaxNumber = item.FaxNumber,
                          FirstName = item.FirstName,
                          Function = item.Function,
                          Id = item.Id,
                          LastName = item.LastName,
                          MobilePhoneNumber = item.MobilePhoneNumber,
                          Observation = item.Observation,
                          Partner = new PartnersService().Get(new Partners() { Ids = new List<int>() { item.PartnerId } }).Partners.FirstOrDefault(),
                          PhoneNumber = item.PhoneNumber,
                          StartingDate = item.StartingDate
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.PartnerContacts.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.PartnerContacts.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.PartnerContacts.Count + (collection.Count() % response.PartnerContacts.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public PartnerContactsResponse Post(PartnerContacts request)
    {
      if (request.PartnerContact.Id > 0)
      {
        Bm2s.Data.Common.BLL.Partner.PartnerContact item = Datas.Instance.DataStorage.PartnerContacts[request.PartnerContact.Id];
        item.Email = request.PartnerContact.Email;
        item.EndingDate = request.PartnerContact.EndingDate;
        item.FaxNumber = request.PartnerContact.FaxNumber;
        item.FirstName = request.PartnerContact.FirstName;
        item.Function = request.PartnerContact.Function;
        item.LastName = request.PartnerContact.LastName;
        item.MobilePhoneNumber = request.PartnerContact.MobilePhoneNumber;
        item.Observation = request.PartnerContact.Observation;
        item.PartnerId = request.PartnerContact.Partner.Id;
        item.PhoneNumber = request.PartnerContact.PhoneNumber;
        item.StartingDate = request.PartnerContact.StartingDate;
        Datas.Instance.DataStorage.PartnerContacts[request.PartnerContact.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Partner.PartnerContact item = new Data.Common.BLL.Partner.PartnerContact()
        {
          Email = request.PartnerContact.Email,
          EndingDate = request.PartnerContact.EndingDate,
          FaxNumber = request.PartnerContact.FaxNumber,
          FirstName = request.PartnerContact.FirstName,
          Function = request.PartnerContact.Function,
          LastName = request.PartnerContact.LastName,
          MobilePhoneNumber = request.PartnerContact.MobilePhoneNumber,
          Observation = request.PartnerContact.Observation,
          PartnerId = request.PartnerContact.Partner.Id,
          PhoneNumber = request.PartnerContact.PhoneNumber,
          StartingDate = request.PartnerContact.StartingDate
        };

        Datas.Instance.DataStorage.PartnerContacts.Add(item);
        request.PartnerContact.Id = item.Id;
      }

      PartnerContactsResponse response = new PartnerContactsResponse();
      response.PartnerContacts.Add(request.PartnerContact);
      return response;
    }

    public PartnerContactsResponse Delete(PartnerContacts request)
    {
      Bm2s.Data.Common.BLL.Partner.PartnerContact item = Datas.Instance.DataStorage.PartnerContacts[request.PartnerContact.Id];
      item.EndingDate = DateTime.Now;
      Datas.Instance.DataStorage.PartnerContacts[item.Id] = item;

      PartnerContactsResponse response = new PartnerContactsResponse();
      response.PartnerContacts.Add(request.PartnerContact);
      return response;
    }
  }
}
