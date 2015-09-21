using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Parameter.InventoryHeader;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.InventoryHeader
{
  public class InventoryHeadersService : Service
  {
    public InventoryHeadersResponse Get(InventoryHeaders request)
    {
      InventoryHeadersResponse response = new InventoryHeadersResponse();
      List<Bm2s.Data.Common.BLL.Parameter.InventoryHeader> items = new List<Data.Common.BLL.Parameter.InventoryHeader>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.InventoryHeaders.Where(item =>
          (request.Type == 0 || item.Type == request.Type) &&
          (!request.Date.HasValue || request.Date >= item.Date)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.InventoryHeaders.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Parameter.InventoryHeader()
                        {
                          Date = item.Date,
                          Id = item.Id,
                          Type = item.Type
                        }).AsQueryable().OrderBy(request.Order, request.AscendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.InventoryHeaders.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.InventoryHeaders.AddRange(collection);
      }
      response.PagesCount = collection.Count() / response.InventoryHeaders.Count + (collection.Count() % response.InventoryHeaders.Count > 0 ? 1 : 0);

      return response;
    }

    public InventoryHeadersResponse Post(InventoryHeaders request)
    {
      if (request.InventoryHeader.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.InventoryHeader item = Datas.Instance.DataStorage.InventoryHeaders[request.InventoryHeader.Id];
        item.Date = request.InventoryHeader.Date;
        item.Id = request.InventoryHeader.Id;
        item.Type = request.InventoryHeader.Type;
        Datas.Instance.DataStorage.InventoryHeaders[request.InventoryHeader.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.InventoryHeader item = new Data.Common.BLL.Parameter.InventoryHeader()
        {
          Date = request.InventoryHeader.Date,
          Id = request.InventoryHeader.Id,
          Type = request.InventoryHeader.Type
        };

        Datas.Instance.DataStorage.InventoryHeaders.Add(item);
        request.InventoryHeader.Id = item.Id;
      }

      InventoryHeadersResponse response = new InventoryHeadersResponse();
      response.InventoryHeaders.Add(request.InventoryHeader);
      return response;
    }
  }
}
