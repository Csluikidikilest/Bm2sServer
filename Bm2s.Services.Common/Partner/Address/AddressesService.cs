using System.Collections.Generic;
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

      response.Addresses.AddRange((from item in items
                                  select new Bm2s.Poco.Common.Partner.Address()
                                  {
                                    CountryName = item.CountryName,
                                    Id = item.Id,
                                    TownName = item.TownName,
                                    TownZipCode = item.TownZipCode
                                  }).AsQueryable().OrderBy(request.Order, request.AscendingOrder).Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));

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
  }
}
