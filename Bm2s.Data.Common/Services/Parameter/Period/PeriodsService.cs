using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Parameter.Period
{
  public class PeriodsService : Service
  {
    public object Get(Periods request)
    {
      PeriodsResponse response = new PeriodsResponse();

      if (!request.Ids.Any())
      {
        response.Periods.AddRange(Datas.Instance.DataStorage.Periods);
      }
      else
      {
        response.Periods.AddRange(Datas.Instance.DataStorage.Periods.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(Periods request)
    {
      if (request.Period.Id > 0)
      {
        Datas.Instance.DataStorage.Periods[request.Period.Id] = request.Period;
      }
      else
      {
        Datas.Instance.DataStorage.Periods.Add(request.Period);
      }
      return request.Period;
    }
  }
}
