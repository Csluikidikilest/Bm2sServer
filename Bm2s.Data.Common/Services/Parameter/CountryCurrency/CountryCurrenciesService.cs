using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Parameter.CountryCurrency
{
  public class CountryCurrenciesService : Service
  {
    public object Get(CountryCurrencies request)
    {
      CountryCurrenciesResponse response = new CountryCurrenciesResponse();

      if (!request.Ids.Any())
      {
        response.CountryCurrencies.AddRange(Datas.Instance.DataStorage.CountryCurrencies);
      }
      else
      {
        response.CountryCurrencies.AddRange(Datas.Instance.DataStorage.CountryCurrencies.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(CountryCurrencies request)
    {
      if (request.CountryCurrency.Id > 0)
      {
        Datas.Instance.DataStorage.CountryCurrencies[request.CountryCurrency.Id] = request.CountryCurrency;
      }
      else
      {
        Datas.Instance.DataStorage.CountryCurrencies.Add(request.CountryCurrency);
      }
      return request.CountryCurrency;
    }
  }
}
