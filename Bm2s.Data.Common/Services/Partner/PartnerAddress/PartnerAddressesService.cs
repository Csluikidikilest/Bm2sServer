using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Partner.PartnerAddress
{
  class PartnerAddressesService : Service
  {
    public object Get(PartnerAddresses request)
    {
      PartnerAddressesResponse response = new PartnerAddressesResponse();

      if (!request.Ids.Any())
      {
        response.PartnerAddresses.AddRange(Datas.Instance.DataStorage.PartnerAddresses);
      }
      else
      {
        response.PartnerAddresses.AddRange(Datas.Instance.DataStorage.PartnerAddresses.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(PartnerAddresses request)
    {
      if (request.PartnerAddress.Id > 0)
      {
        Datas.Instance.DataStorage.PartnerAddresses[request.PartnerAddress.Id] = request.PartnerAddress;
      }
      else
      {
        Datas.Instance.DataStorage.PartnerAddresses.Add(request.PartnerAddress);
      }
      return request.PartnerAddress;
    }
  }
}
