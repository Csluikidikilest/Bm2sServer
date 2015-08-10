using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Partner.Partner
{
  class PartnersService : Service
  {
    public object Get(Partners request)
    {
      PartnersResponse response = new PartnersResponse();

      if (!request.Ids.Any())
      {
        response.Partners.AddRange(Datas.Instance.DataStorage.Partners.Where(item =>
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
