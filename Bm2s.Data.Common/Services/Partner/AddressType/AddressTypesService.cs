using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Partner.AddressType
{
  class AddressTypesService : Service
  {
    public object Get(AddressTypes request)
    {
      AddressTypesResponse response = new AddressTypesResponse();

      if (!request.Ids.Any())
      {
        response.AddressTypes.AddRange(Datas.Instance.DataStorage.AddressTypes);
      }
      else
      {
        response.AddressTypes.AddRange(Datas.Instance.DataStorage.AddressTypes.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(AddressTypes request)
    {
      if (request.AddressType.Id > 0)
      {
        Datas.Instance.DataStorage.AddressTypes[request.AddressType.Id] = request.AddressType;
      }
      else
      {
        Datas.Instance.DataStorage.AddressTypes.Add(request.AddressType);
      }
      return request.AddressType;
    }
  }
}
