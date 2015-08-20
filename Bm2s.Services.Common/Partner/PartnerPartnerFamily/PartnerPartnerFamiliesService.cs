using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Services.Common.Partner.Partner;
using Bm2s.Services.Common.Partner.PartnerFamily;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Partner.PartnerPartnerFamily
{
  class PartnerPartnerFamiliesService : Service
  {
    public PartnerPartnerFamiliesResponse Get(PartnerPartnerFamilies request)
    {
      PartnerPartnerFamiliesResponse response = new PartnerPartnerFamiliesResponse();
      List<Bm2s.Data.Common.BLL.Partner.PartnerPartnerFamily> items = new List<Data.Common.BLL.Partner.PartnerPartnerFamily>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.PartnerPartnerFamilies.Where(item =>
          (request.PartnerId == 0 || item.PartnerId == request.PartnerId) &&
          (request.PartnerFamilyId == 0 || item.PartnerFamilyId == request.PartnerFamilyId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.PartnerPartnerFamilies.Where(item => request.Ids.Contains(item.Id)));
      }

      response.PartnerPartnerFamilies.AddRange(from item in items
                                               select new Bm2s.Poco.Common.Partner.PartnerPartnerFamily()
                                               {
                                                 Id = item.Id,
                                                 Partner = new PartnersService().Get(new Partners() { Ids = new List<int>() { item.PartnerId} }).Partners.FirstOrDefault(),
                                                 PartnerFamily = new PartnerFamiliesService().Get(new PartnerFamilies() { Ids = new List<int>() { item.PartnerFamilyId} }).PartnerFamilies.FirstOrDefault()
                                               });

      return response;
    }

    public Bm2s.Poco.Common.Partner.PartnerPartnerFamily Post(PartnerPartnerFamilies request)
    {
      if (request.PartnerPartnerFamily.Id > 0)
      {
        Bm2s.Data.Common.BLL.Partner.PartnerPartnerFamily item = Datas.Instance.DataStorage.PartnerPartnerFamilies[request.PartnerPartnerFamily.Id];
        item.PartnerFamilyId = request.PartnerPartnerFamily.PartnerFamily.Id;
        item.PartnerId = request.PartnerPartnerFamily.Partner.Id;
        Datas.Instance.DataStorage.PartnerPartnerFamilies[request.PartnerPartnerFamily.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Partner.PartnerPartnerFamily item = new Data.Common.BLL.Partner.PartnerPartnerFamily()
        {
          PartnerFamilyId = request.PartnerPartnerFamily.PartnerFamily.Id,
          PartnerId = request.PartnerPartnerFamily.Partner.Id
        };

        Datas.Instance.DataStorage.PartnerPartnerFamilies.Add(item);
        request.PartnerPartnerFamily.Id = item.Id;
      }

      return request.PartnerPartnerFamily;
    }
  }
}
