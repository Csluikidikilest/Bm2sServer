using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Partner.PartnerFamily;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Partner.PartnerFamily
{
  class PartnerFamiliesService : Service
  {
    public PartnerFamiliesResponse Get(PartnerFamilies request)
    {
      PartnerFamiliesResponse response = new PartnerFamiliesResponse();
      List<Bm2s.Data.Common.BLL.Partner.PartnerFamily> items = new List<Data.Common.BLL.Partner.PartnerFamily>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.PartnerFamilies.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Designation) || item.Designation.ToLower().Contains(request.Designation.ToLower())) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.PartnerFamilies.Where(item => request.Ids.Contains(item.Id)));
      }

      response.PartnerFamilies.AddRange(from item in items
                                        select new Bm2s.Poco.Common.Partner.PartnerFamily()
                                        {
                                          Code = item.Code,
                                          Description = item.Description,
                                          Designation = item.Designation,
                                          EndingDate = item.EndingDate,
                                          Id = item.Id,
                                          StartingDate = item.StartingDate
                                        });

      return response;
    }

    public PartnerFamiliesResponse Post(PartnerFamilies request)
    {
      if (request.PartnerFamily.Id > 0)
      {
        Bm2s.Data.Common.BLL.Partner.PartnerFamily item = Datas.Instance.DataStorage.PartnerFamilies[request.PartnerFamily.Id];
        item.Code = request.PartnerFamily.Code;
        item.Description = request.PartnerFamily.Description;
        item.Designation = request.PartnerFamily.Designation;
        item.EndingDate = request.PartnerFamily.EndingDate;
        item.StartingDate = request.PartnerFamily.StartingDate;
        Datas.Instance.DataStorage.PartnerFamilies[request.PartnerFamily.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Partner.PartnerFamily item = new Data.Common.BLL.Partner.PartnerFamily()
        {
          Code = request.PartnerFamily.Code,
          Description = request.PartnerFamily.Description,
          Designation = request.PartnerFamily.Designation,
          EndingDate = request.PartnerFamily.EndingDate,
          StartingDate = request.PartnerFamily.StartingDate
        };

        Datas.Instance.DataStorage.PartnerFamilies.Add(item);
        request.PartnerFamily.Id = item.Id;
      }

      PartnerFamiliesResponse response = new PartnerFamiliesResponse();
      response.PartnerFamilies.Add(request.PartnerFamily);
      return response;
    }
  }
}
