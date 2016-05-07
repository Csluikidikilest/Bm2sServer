using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Partner.Address;
using Bm2s.Response.Common.Partner.AddressType;
using Bm2s.Response.Common.Partner.Partner;
using Bm2s.Response.Common.Partner.PartnerAddress;
using Bm2s.Services.Common.Partner.Address;
using Bm2s.Services.Common.Partner.AddressType;
using Bm2s.Services.Common.Partner.Partner;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Partner.PartnerAddress
{
  class PartnerAddressesService : Service
  {
    public PartnerAddressesResponse Get(PartnerAddresses request)
    {
      PartnerAddressesResponse response = new PartnerAddressesResponse();
      List<Bm2s.Data.Common.BLL.Partner.PartnerAddress> items = new List<Data.Common.BLL.Partner.PartnerAddress>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.PartnerAddresses.Where(item =>
          (request.AddressId == 0 || item.AddressId == request.AddressId) &&
          (request.AddressTypeId == 0 || item.AddressTypeId == request.AddressTypeId) &&
          (request.PartnerId == 0 || item.PartnerId == request.PartnerId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.PartnerAddresses.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Partner.PartnerAddress()
                        {
                          Address = new AddressesService().Get(new Addresses() { Ids = new List<int>() { item.AddressId } }).Addresses.FirstOrDefault(),
                          AddressType = new AddressTypesService().Get(new AddressTypes() { Ids = new List<int>() { item.AddressTypeId } }).AddressTypes.FirstOrDefault(),
                          Id = item.Id,
                          Partner = new PartnersService().Get(new Partners() { Ids = new List<int>() { item.PartnerId } }).Partners.FirstOrDefault()
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.PartnerAddresses.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.PartnerAddresses.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.PartnerAddresses.Count + (collection.Count() % response.PartnerAddresses.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public PartnerAddressesResponse Post(PartnerAddresses request)
    {
      if (request.PartnerAddress.Id > 0)
      {
        Bm2s.Data.Common.BLL.Partner.PartnerAddress item = Datas.Instance.DataStorage.PartnerAddresses[request.PartnerAddress.Id];
        item.AddressId = request.PartnerAddress.Address.Id;
        item.AddressTypeId = request.PartnerAddress.AddressType.Id;
        item.PartnerId = request.PartnerAddress.Partner.Id;
        Datas.Instance.DataStorage.PartnerAddresses[request.PartnerAddress.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Partner.PartnerAddress item = new Data.Common.BLL.Partner.PartnerAddress()
        {
          AddressId = request.PartnerAddress.Address.Id,
          AddressTypeId = request.PartnerAddress.AddressType.Id,
          PartnerId = request.PartnerAddress.Partner.Id
        };

        Datas.Instance.DataStorage.PartnerAddresses.Add(item);
        request.PartnerAddress.Id = item.Id;
      }

      PartnerAddressesResponse response = new PartnerAddressesResponse();
      response.PartnerAddresses.Add(request.PartnerAddress);
      return response;
    }

    public PartnerAddressesResponse Delete(PartnerAddresses request)
    {
      Bm2s.Data.Common.BLL.Partner.PartnerAddress item = Datas.Instance.DataStorage.PartnerAddresses[request.PartnerAddress.Id];
      Datas.Instance.DataStorage.PartnerAddresses.Remove(item);
      Datas.Instance.DataStorage.PartnerAddresses[item.Id] = item;

      PartnerAddressesResponse response = new PartnerAddressesResponse();
      response.PartnerAddresses.Add(request.PartnerAddress);
      return response;
    }
  }
}
