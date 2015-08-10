using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Partner.PartnerPartnerFamily
{
  class PartnerPartnerFamiliesService : Service
  {
    public object Get(PartnerPartnerFamilies request)
    {
      PartnerPartnerFamiliesResponse response = new PartnerPartnerFamiliesResponse();

      if (!request.Ids.Any())
      {
        response.PartnerPartnerFamilies.AddRange(Datas.Instance.DataStorage.PartnerPartnerFamilies.Where(item =>
          (request.PartnerId == 0 || item.PartnerId == request.PartnerId) &&
          (request.PartnerFamilyId == 0 || item.PartnerFamilyId == request.PartnerFamilyId)
          ));
      }
      else
      {
        response.PartnerPartnerFamilies.AddRange(Datas.Instance.DataStorage.PartnerPartnerFamilies.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(PartnerPartnerFamilies request)
    {
      if (request.PartnerPartnerFamily.Id > 0)
      {
        Datas.Instance.DataStorage.PartnerPartnerFamilies[request.PartnerPartnerFamily.Id] = request.PartnerPartnerFamily;
      }
      else
      {
        Datas.Instance.DataStorage.PartnerPartnerFamilies.Add(request.PartnerPartnerFamily);
      }
      return request.PartnerPartnerFamily;
    }
  }
}
