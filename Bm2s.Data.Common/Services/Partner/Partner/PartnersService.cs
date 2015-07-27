using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Partner.Partner
{
  class PartnersService : Service
  {
    public object Get(Partners request)
    {
      PartnersResponse response = new PartnersResponse();

      if (!request.Ids.Any())
      {
        response.Partners.AddRange(Datas.Instance.DataStorage.Partners);
      }
      else
      {
        response.Partners.AddRange(Datas.Instance.DataStorage.Partners.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(Partners request)
    {
      if (request.Partner.Id > 0)
      {
        Datas.Instance.DataStorage.Partners[request.Partner.Id] = request.Partner;
      }
      else
      {
        Datas.Instance.DataStorage.Partners.Add(request.Partner);
      }
      return request.Partner;
    }
  }
}
