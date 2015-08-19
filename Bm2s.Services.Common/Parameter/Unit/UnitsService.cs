using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.Unit
{
  public class UnitsService : Service
  {
    public UnitsResponse Get(Units request)
    {
      UnitsResponse response = new UnitsResponse();
      List<Bm2s.Data.Common.BLL.Parameter.Unit> items = new List<Data.Common.BLL.Parameter.Unit>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Units.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower())) &&
          (!request.IsCurrency || item.IsCurrency) &&
          (!request.IsPeriod || item.IsPeriod) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Units.Where(item => request.Ids.Contains(item.Id)));
      }

      response.Units.AddRange(from item in items
                              select new Bm2s.Poco.Common.Parameter.Unit()
                              {
                                Code = item.Code,
                                Description = item.Description,
                                EndingDate = item.EndingDate,
                                Id = item.Id,
                                IsCurrency = item.IsCurrency,
                                IsPeriod = item.IsPeriod,
                                Name = item.Name,
                                StartingDate = item.StartingDate
                              });

      return response;
    }

    public Bm2s.Poco.Common.Parameter.Unit Post(Units request)
    {
      if (request.Unit.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.Unit item = Datas.Instance.DataStorage.Units[request.Unit.Id];
        item.Code = request.Unit.Code;
        item.Description = request.Unit.Description;
        item.EndingDate = request.Unit.EndingDate;
        item.IsCurrency = request.Unit.IsCurrency;
        item.IsPeriod = request.Unit.IsPeriod;
        item.Name = request.Unit.Name;
        item.StartingDate = request.Unit.StartingDate;
        Datas.Instance.DataStorage.Units[request.Unit.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.Unit item = new Data.Common.BLL.Parameter.Unit()
        {
          Code = request.Unit.Code,
          Description = request.Unit.Description,
          EndingDate = request.Unit.EndingDate,
          IsCurrency = request.Unit.IsCurrency,
          IsPeriod = request.Unit.IsPeriod,
          Name = request.Unit.Name,
          StartingDate = request.Unit.StartingDate
        };

        Datas.Instance.DataStorage.Units.Add(item);
        request.Unit.Id = item.Id;
      }

      return request.Unit;
    }
  }
}
