using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Partner.Address;
using Bm2s.Response.Common.Partner.AddressType;
using Bm2s.Response.Common.Partner.Partner;
using Bm2s.Response.Common.Trade.Header;
using Bm2s.Response.Common.Trade.HeaderPartnerAddress;
using Bm2s.Services.Common.Partner.Address;
using Bm2s.Services.Common.Partner.AddressType;
using Bm2s.Services.Common.Partner.Partner;
using Bm2s.Services.Common.Trade.Header;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Trade.HeaderPartnerAddress
{
  public class HeaderPartnerAddressesService : Service
  {
    public HeaderPartnerAddressesResponse Get(HeaderPartnerAddresses request)
    {
      HeaderPartnerAddressesResponse response = new HeaderPartnerAddressesResponse();
      List<Bm2s.Data.Common.BLL.Trade.HeaderPartnerAddress> items = new List<Data.Common.BLL.Trade.HeaderPartnerAddress>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.HeaderPartnerAddresses.Where(item =>
          (request.AddressId == 0 || item.AddressId == request.AddressId) &&
          (request.AddressTypeId == 0 || item.AddressTypeId == request.AddressTypeId) &&
          (request.HeaderId == 0 || item.HeaderId == request.HeaderId) &&
          (request.PartnerId == 0 || item.PartnerId == request.PartnerId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.HeaderPartnerAddresses.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Trade.HeaderPartnerAddress()
                        {
                          Address = new AddressesService().Get(new Addresses() { Ids = new List<int>() { item.AddressId } }).Addresses.FirstOrDefault(),
                          AddressType = new AddressTypesService().Get(new AddressTypes() { Ids = new List<int>() { item.AddressTypeId } }).AddressTypes.FirstOrDefault(),
                          Header = new HeadersService().Get(new Headers() { Ids = new List<int>() { item.HeaderId } }).Headers.FirstOrDefault(),
                          Id = item.Id,
                          Partner = new PartnersService().Get(new Partners() { Ids = new List<int>() { item.PartnerId } }).Partners.FirstOrDefault()
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.HeaderPartnerAddresses.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.HeaderPartnerAddresses.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.HeaderPartnerAddresses.Count + (collection.Count() % response.HeaderPartnerAddresses.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public HeaderPartnerAddressesResponse Post(HeaderPartnerAddresses request)
    {
      if (request.HeaderPartnerAddress.Id > 0)
      {
        Bm2s.Data.Common.BLL.Trade.HeaderPartnerAddress item = Datas.Instance.DataStorage.HeaderPartnerAddresses[request.HeaderPartnerAddress.Id];
        item.AddressId = request.HeaderPartnerAddress.Address.Id;
        item.AddressTypeId = request.HeaderPartnerAddress.AddressType.Id;
        item.HeaderId = request.HeaderPartnerAddress.Header.Id;
        item.PartnerId = request.HeaderPartnerAddress.Partner.Id;
        Datas.Instance.DataStorage.HeaderPartnerAddresses[request.HeaderPartnerAddress.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Trade.HeaderPartnerAddress item = new Data.Common.BLL.Trade.HeaderPartnerAddress()
        {
          AddressId = request.HeaderPartnerAddress.Address.Id,
          AddressTypeId = request.HeaderPartnerAddress.AddressType.Id,
          HeaderId = request.HeaderPartnerAddress.Header.Id,
          PartnerId = request.HeaderPartnerAddress.Partner.Id
        };

        Datas.Instance.DataStorage.HeaderPartnerAddresses.Add(item);
        request.HeaderPartnerAddress.Id = item.Id;
      }

      HeaderPartnerAddressesResponse response = new HeaderPartnerAddressesResponse();
      response.HeaderPartnerAddresses.Add(request.HeaderPartnerAddress);
      return response;
    }

    public bool Delete(Articles request)
    {
      bool result = true;
      Bm2s.Data.Common.BLL.Article.Article item = Datas.Instance.DataStorage.Articles.FirstOrDefault(nomenclature => nomenclature.Id == request.Article.Id);
      if (item != null)
      {
        result = Datas.Instance.DataStorage.Articles.Remove(item);
      }

      return result;
    }
  }
}
