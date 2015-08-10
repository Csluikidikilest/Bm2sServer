using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.Period
{
  public class PeriodsService : Service
  {
    public object Get(Periods request)
    {
      PeriodsResponse response = new PeriodsResponse();

      if (!request.Ids.Any())
      {
        response.Periods.AddRange(Datas.Instance.DataStorage.Periods.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower())) &&
          (request.UnitId == 0 || item.UnitId == request.UnitId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
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
