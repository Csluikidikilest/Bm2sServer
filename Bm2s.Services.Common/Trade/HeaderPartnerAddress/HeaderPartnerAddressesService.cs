using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Trade.HeaderPartnerAddress
{
  public class HeaderPartnerAddressesService : Service
  {
    public object Get(HeaderPartnerAddresses request)
    {
      HeaderPartnerAddressesResponse response = new HeaderPartnerAddressesResponse();

      if (!request.Ids.Any())
      {
        response.HeaderPartnerAddresses.AddRange(Datas.Instance.DataStorage.HeaderPartnerAddresses.Where(item =>
          (request.AddressId == 0 || item.AddressId == request.AddressId) &&
          (request.AddressTypeId == 0 || item.AddressTypeId == request.AddressTypeId) &&
          (request.HeaderId == 0 || item.HeaderId == request.HeaderId) &&
          (request.PartnerId == 0 || item.PartnerId == request.PartnerId)
          ));
      }
      else
      {
        response.HeaderPartnerAddresses.AddRange(Datas.Instance.DataStorage.HeaderPartnerAddresses.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(HeaderPartnerAddresses request)
    {
      if (request.HeaderPartnerAddress.Id > 0)
      {
        Datas.Instance.DataStorage.HeaderPartnerAddresses[request.HeaderPartnerAddress.Id] = request.HeaderPartnerAddress;
      }
      else
      {
        Datas.Instance.DataStorage.HeaderPartnerAddresses.Add(request.HeaderPartnerAddress);
      }
      return request.HeaderPartnerAddress;
    }
  }
}
