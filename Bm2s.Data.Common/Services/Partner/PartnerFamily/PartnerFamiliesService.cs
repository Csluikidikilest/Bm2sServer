using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Partner.PartnerFamily
{
  class PartnerFamiliesService : Service
  {
    public object Get(PartnerFamilies request)
    {
      PartnerFamiliesResponse response = new PartnerFamiliesResponse();

      if (!request.Ids.Any())
      {
        response.PartnerFamilies.AddRange(Datas.Instance.DataStorage.PartnerFamilies);
      }
      else
      {
        response.PartnerFamilies.AddRange(Datas.Instance.DataStorage.PartnerFamilies.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(PartnerFamilies request)
    {
      if (request.PartnerFamily.Id > 0)
      {
        Datas.Instance.DataStorage.PartnerFamilies[request.PartnerFamily.Id] = request.PartnerFamily;
      }
      else
      {
        Datas.Instance.DataStorage.PartnerFamilies.Add(request.PartnerFamily);
      }
      return request.PartnerFamily;
    }
  }
}
