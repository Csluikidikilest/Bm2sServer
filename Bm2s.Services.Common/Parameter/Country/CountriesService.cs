using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.Country
{
  public class CountriesService : Service
  {
    public object Get(Countries request)
    {
      CountriesResponse response = new CountriesResponse();

      if (!request.Ids.Any())
      {
        response.Countries.AddRange(Datas.Instance.DataStorage.Countries.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower())) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        response.Countries.AddRange(Datas.Instance.DataStorage.Countries.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(Countries request)
    {
      if (request.Country.Id > 0)
      {
        Datas.Instance.DataStorage.Countries[request.Country.Id] = request.Country;
      }
      else
      {
        Datas.Instance.DataStorage.Countries.Add(request.Country);
      }
      return request.Country;
    }
  }
}
