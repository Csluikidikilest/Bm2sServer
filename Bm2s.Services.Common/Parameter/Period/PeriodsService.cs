using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Services.Common.Parameter.Unit;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.Period
{
  public class PeriodsService : Service
  {
    public PeriodsResponse Get(Periods request)
    {
      PeriodsResponse response = new PeriodsResponse();
      List<Bm2s.Data.Common.BLL.Parameter.Period> items = new List<Data.Common.BLL.Parameter.Period>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Periods.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower())) &&
          (request.UnitId == 0 || item.UnitId == request.UnitId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Periods.Where(item => request.Ids.Contains(item.Id)));
      }

      response.Periods.AddRange(from item in items
                                select new Bm2s.Poco.Common.Parameter.Period()
                                {
                                  Code = item.Code,
                                  EndingDate = item.EndingDate,
                                  Id = item.Id,
                                  Interval = item.Interval,
                                  Name = item.Name,
                                  StartingDate = item.StartingDate,
                                  Unit = new UnitsService().Get(new Units() { Ids = new List<int>() { item.UnitId } }).Units.FirstOrDefault()
                                });

      return response;
    }

    public Bm2s.Poco.Common.Parameter.Period Post(Periods request)
    {
      if (request.Period.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.Period item = Datas.Instance.DataStorage.Periods[request.Period.Id];
        item.Code = request.Period.Code;
        item.EndingDate = request.Period.EndingDate;
        item.Interval = request.Period.Interval;
        item.Name = request.Period.Name;
        item.StartingDate = request.Period.StartingDate;
        item.UnitId = request.Period.Unit.Id;
        Datas.Instance.DataStorage.Periods[request.Period.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.Period item = new Data.Common.BLL.Parameter.Period()
        {
          Code = request.Period.Code,
          EndingDate = request.Period.EndingDate,
          Interval = request.Period.Interval,
          Name = request.Period.Name,
          StartingDate = request.Period.StartingDate,
          UnitId = request.Period.Unit.Id
        };

        Datas.Instance.DataStorage.Periods.Add(item);
        request.Period.Id = item.Id;
      }

      return request.Period;
    }
  }
}
