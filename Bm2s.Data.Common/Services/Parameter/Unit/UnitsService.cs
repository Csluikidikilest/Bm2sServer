using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Parameter.Unit
{
  public class UnitsService : Service
  {
    public object Get(Units request)
    {
      UnitsResponse response = new UnitsResponse();

      if (!request.Ids.Any())
      {
        response.Units.AddRange(Datas.Instance.DataStorage.Units.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower())) &&
          (!request.IsCurrency || item.IsCurrency) &&
          (!request.IsPeriod || item.IsPeriod) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        response.Units.AddRange(Datas.Instance.DataStorage.Units.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(Units request)
    {
      if (request.Unit.Id > 0)
      {
        Datas.Instance.DataStorage.Units[request.Unit.Id] = request.Unit;
      }
      else
      {
        Datas.Instance.DataStorage.Units.Add(request.Unit);
      }
      return request.Unit;
    }
  }
}
