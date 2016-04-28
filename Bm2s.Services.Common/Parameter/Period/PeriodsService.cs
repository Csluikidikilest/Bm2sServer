using System;
using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Parameter.Period;
using Bm2s.Response.Common.Parameter.Unit;
using Bm2s.Services.Common.Parameter.Unit;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.Period
{
  public class PeriodsService : Service
  {
    public PeriodsResponse Get(Periods request)
    {
      PeriodsResponse response = new PeriodsResponse();
      List<Bm2s.Data.Common.BLL.Parameter.Peri> items = new List<Data.Common.BLL.Parameter.Peri>();
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

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Parameter.Period()
                        {
                          Code = item.Code,
                          EndingDate = item.EndingDate,
                          Id = item.Id,
                          Interval = item.Interval,
                          Name = item.Name,
                          StartingDate = item.StartingDate,
                          Unit = new UnitsService().Get(new Units() { Ids = new List<int>() { item.UnitId } }).Units.FirstOrDefault()
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.Periods.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.Periods.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.Periods.Count + (collection.Count() % response.Periods.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public PeriodsResponse Post(Periods request)
    {
      if (request.Period.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.Peri item = Datas.Instance.DataStorage.Periods[request.Period.Id];
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
        Bm2s.Data.Common.BLL.Parameter.Peri item = new Data.Common.BLL.Parameter.Peri()
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

      PeriodsResponse response = new PeriodsResponse();
      response.Periods.Add(request.Period);
      return response;
    }

    public PeriodsResponse Delete(Periods request)
    {
      Bm2s.Data.Common.BLL.Parameter.Peri item = Datas.Instance.DataStorage.Periods[request.Period.Id];
      item.EndingDate = DateTime.Now;
      Datas.Instance.DataStorage.Periods[item.Id] = item;

      PeriodsResponse response = new PeriodsResponse();
      response.Periods.Add(request.Period);
      return response;
    }
  }
}
