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

      response.PartnerAddresses.AddRange(from item in items
                                         select new Bm2s.Poco.Common.Partner.PartnerAddress()
                                         {
                                           Address = new AddressesService().Get(new Addresses() { Ids = new List<int>() { item.AddressId } }).Addresses.FirstOrDefault(),
                                           AddressType = new AddressTypesService().Get(new AddressTypes() { Ids = new List<int>() { item.AddressTypeId } }).AddressTypes.FirstOrDefault(),
                                           Id = item.Id,
                                           Partner = new PartnersService().Get(new Partners() { Ids = new List<int>() { item.PartnerId } }).Partners.FirstOrDefault()
                                         });

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
  }
}
