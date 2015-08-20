using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Services.Common.User.User;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Partner.Partner
{
  class PartnersService : Service
  {
    public PartnersResponse Get(Partners request)
    {
      PartnersResponse response = new PartnersResponse();
      List<Bm2s.Data.Common.BLL.Partner.Partner> items = new List<Data.Common.BLL.Partner.Partner>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Partners.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.CompanyName) || item.CompanyName.ToLower().Contains(request.CompanyName.ToLower())) &&
          (!request.IsCustomer || item.IsCustomer) &&
          (!request.IsSupplier || item.IsSupplier) &&
          (request.UserId == 0 || item.UserId == request.UserId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Partners.Where(item => request.Ids.Contains(item.Id)));
      }

      response.Partners.AddRange(from item in items
                                 select new Bm2s.Poco.Common.Partner.Partner()
                                 {
                                   Code = item.Code,
                                   CompanyIdentifier = item.CompanyIdentifier,
                                   CompanyName = item.CompanyName,
                                   Email = item.Email,
                                   EndingDate = item.EndingDate,
                                   FaxNumber = item.FaxNumber,
                                   Id = item.Id,
                                   IsCustomer = item.IsCustomer,
                                   IsSupplier = item.IsSupplier,
                                   Observation = item.Observation,
                                   PhoneNumber = item.PhoneNumber,
                                   PriceMultiplier = item.PriceMultiplier,
                                   StartingDate = item.StartingDate,
                                   User = new UsersService().Get(new Users() { Ids = new List<int>() { item.UserId } }).Users.FirstOrDefault(),
                                   WebSite = item.WebSite
                                 });

      return response;
    }

    public Bm2s.Poco.Common.Partner.Partner Post(Partners request)
    {
      if (request.Partner.Id > 0)
      {
        Bm2s.Data.Common.BLL.Partner.Partner item = Datas.Instance.DataStorage.Partners[request.Partner.Id];
        item.Code = request.Partner.Code;
        item.CompanyIdentifier = item.CompanyIdentifier;
        item.CompanyName = request.Partner.CompanyName;
        item.Email = request.Partner.Email;
        item.EndingDate = request.Partner.EndingDate;
        item.FaxNumber = request.Partner.FaxNumber;
        item.IsCustomer = request.Partner.IsCustomer;
        item.IsSupplier = request.Partner.IsSupplier;
        item.Observation = request.Partner.Observation;
        item.PhoneNumber = request.Partner.PhoneNumber;
        item.PriceMultiplier = request.Partner.PriceMultiplier;
        item.StartingDate = request.Partner.StartingDate;
        item.UserId = request.Partner.User.Id;
        item.WebSite = request.Partner.WebSite;
        Datas.Instance.DataStorage.Partners[request.Partner.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Partner.Partner item = new Data.Common.BLL.Partner.Partner()
        {
          Code = request.Partner.Code,
          CompanyIdentifier = item.CompanyIdentifier,
          CompanyName = request.Partner.CompanyName,
          Email = request.Partner.Email,
          EndingDate = request.Partner.EndingDate,
          FaxNumber = request.Partner.FaxNumber,
          IsCustomer = request.Partner.IsCustomer,
          IsSupplier = request.Partner.IsSupplier,
          Observation = request.Partner.Observation,
          PhoneNumber = request.Partner.PhoneNumber,
          PriceMultiplier = request.Partner.PriceMultiplier,
          StartingDate = request.Partner.StartingDate,
          UserId = request.Partner.User.Id,
          WebSite = request.Partner.WebSite
        };

        Datas.Instance.DataStorage.Partners.Add(item);
        request.Partner.Id = item.Id;
      }

      return request.Partner;
    }
  }
}
