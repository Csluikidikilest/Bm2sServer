using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Partner.Address
{
  class AddressesService : Service
  {
    public object Get(Addresses request)
    {
      AddressesResponse response = new AddressesResponse();

      if (!request.Ids.Any())
      {
        response.Addresses.AddRange(Datas.Instance.DataStorage.Addresses);
      }
      else
      {
        response.Addresses.AddRange(Datas.Instance.DataStorage.Addresses.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(Addresses request)
    {
      if (request.Address.Id > 0)
      {
        Datas.Instance.DataStorage.Addresses[request.Address.Id] = request.Address;
      }
      else
      {
        Datas.Instance.DataStorage.Addresses.Add(request.Address);
      }
      return request.Address;
    }
  }
}
