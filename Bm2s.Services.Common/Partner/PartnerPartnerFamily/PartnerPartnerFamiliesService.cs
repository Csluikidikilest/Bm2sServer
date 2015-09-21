using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Partner.Partner;
using Bm2s.Response.Common.Partner.PartnerFamily;
using Bm2s.Response.Common.Partner.PartnerPartnerFamily;
using Bm2s.Services.Common.Partner.Partner;
using Bm2s.Services.Common.Partner.PartnerFamily;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Partner.PartnerPartnerFamily
{
  public class PartnerPartnerFamiliesService : Service
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

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Partner.PartnerPartnerFamily()
                        {
                          Id = item.Id,
                          Partner = new PartnersService().Get(new Partners() { Ids = new List<int>() { item.PartnerId } }).Partners.FirstOrDefault(),
                          PartnerFamily = new PartnerFamiliesService().Get(new PartnerFamilies() { Ids = new List<int>() { item.PartnerFamilyId } }).PartnerFamilies.FirstOrDefault()
                        }).AsQueryable().OrderBy(request.Order, request.AscendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.PartnerPartnerFamilies.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.PartnerPartnerFamilies.AddRange(collection);
      }
      response.PagesCount = collection.Count() / response.PartnerPartnerFamilies.Count + (collection.Count() % response.PartnerPartnerFamilies.Count > 0 ? 1 : 0);

      return response;
    }

    public PartnerPartnerFamiliesResponse Post(PartnerPartnerFamilies request)
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

      PartnerPartnerFamiliesResponse response = new PartnerPartnerFamiliesResponse();
      response.PartnerPartnerFamilies.Add(request.PartnerPartnerFamily);
      return response;
    }
  }
}
