using System;
using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Trade.HeaderStatus;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Trade.HeaderStatus
{
  public class HeaderStatusesService : Service
  {
    public HeaderStatusesResponse Get(HeaderStatuses request)
    {
      HeaderStatusesResponse response = new HeaderStatusesResponse();
      List<Bm2s.Data.Common.BLL.Trade.HeaderStatus> items = new List<Data.Common.BLL.Trade.HeaderStatus>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.HeaderStatuses.Where(item =>
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value))) &&
          (!request.InterveneOnStock || item.InterveneOnStock) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower()))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.HeaderStatuses.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Trade.HeaderStatus()
                        {
                          EndingDate = item.EndingDate,
                          Id = item.Id,
                          InterveneOnStock = item.InterveneOnStock,
                          Name = item.Name,
                          StartingDate = item.StartingDate
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.HeaderStatuses.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.HeaderStatuses.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.HeaderStatuses.Count + (collection.Count() % response.HeaderStatuses.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public HeaderStatusesResponse Post(HeaderStatuses request)
    {
      if (request.HeaderStatus.Id > 0)
      {
        Bm2s.Data.Common.BLL.Trade.HeaderStatus item = Datas.Instance.DataStorage.HeaderStatuses[request.HeaderStatus.Id];
        item.EndingDate = request.HeaderStatus.EndingDate;
        item.InterveneOnStock = request.HeaderStatus.InterveneOnStock;
        item.Name = request.HeaderStatus.Name;
        item.StartingDate = request.HeaderStatus.StartingDate;
        Datas.Instance.DataStorage.HeaderStatuses[request.HeaderStatus.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Trade.HeaderStatus item = new Data.Common.BLL.Trade.HeaderStatus()
        {
          EndingDate = request.HeaderStatus.EndingDate,
          InterveneOnStock = request.HeaderStatus.InterveneOnStock,
          Name = request.HeaderStatus.Name,
          StartingDate = request.HeaderStatus.StartingDate
        };

        Datas.Instance.DataStorage.HeaderStatuses.Add(item);
        request.HeaderStatus.Id = item.Id;
      }

      HeaderStatusesResponse response = new HeaderStatusesResponse();
      response.HeaderStatuses.Add(request.HeaderStatus);
      return response;
    }

    public HeaderStatusesResponse Delete(HeaderStatuses request)
    {
      Bm2s.Data.Common.BLL.Trade.HeaderStatus item = Datas.Instance.DataStorage.HeaderStatuses[request.HeaderStatus.Id];
      item.EndingDate = DateTime.Now;

      HeaderStatusesResponse response = new HeaderStatusesResponse();
      response.HeaderStatuses.Add(request.HeaderStatus);
      return response;
    }
  }
}
