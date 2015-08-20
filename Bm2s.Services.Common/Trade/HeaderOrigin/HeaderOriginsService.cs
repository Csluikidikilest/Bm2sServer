using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Services.Common.Trade.Header;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Trade.HeaderOrigin
{
  public class HeaderOriginsService : Service
  {
    public HeaderOriginsResponse Get(HeaderOrigins request)
    {
      HeaderOriginsResponse response = new HeaderOriginsResponse();
      List<Bm2s.Data.Common.BLL.Trade.HeaderOrigin> items = new List<Data.Common.BLL.Trade.HeaderOrigin>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.HeaderOrigins.Where(item =>
          (request.HeaderChildId == 0 || item.HeaderChildId == request.HeaderChildId) &&
          (request.HeaderParentId == 0 || item.HeaderParentId == request.HeaderParentId) &&
          (!request.Date.HasValue || request.Date >= item.Date)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.HeaderOrigins.Where(item => request.Ids.Contains(item.Id)));
      }

      response.HeaderOrigins.AddRange(from item in items
                                      select new Bm2s.Poco.Common.Trade.HeaderOrigin()
                                      {
                                        Date = item.Date,
                                        HeaderChild = new HeadersService().Get(new Headers() { Ids = new List<int>() { item.HeaderChildId} }).Headers.FirstOrDefault(),
                                        HeaderParent = new HeadersService().Get(new Headers() { Ids = new List<int>() { item.HeaderParentId } }).Headers.FirstOrDefault(),
                                        Id = item.Id
                                      });

      return response;
    }

    public Bm2s.Poco.Common.Trade.HeaderOrigin Post(HeaderOrigins request)
    {
      if (request.HeaderOrigin.Id > 0)
      {
        Bm2s.Data.Common.BLL.Trade.HeaderOrigin item = Datas.Instance.DataStorage.HeaderOrigins[request.HeaderOrigin.Id];
        item.Date = request.HeaderOrigin.Date;
        item.HeaderChildId = request.HeaderOrigin.HeaderChild.Id;
        item.HeaderParentId = request.HeaderOrigin.HeaderParent.Id;
        Datas.Instance.DataStorage.HeaderOrigins[request.HeaderOrigin.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Trade.HeaderOrigin item = new Data.Common.BLL.Trade.HeaderOrigin()
        {
          Date = request.HeaderOrigin.Date,
          HeaderChildId = request.HeaderOrigin.HeaderChild.Id,
          HeaderParentId = request.HeaderOrigin.HeaderParent.Id
        };

        Datas.Instance.DataStorage.HeaderOrigins.Add(item);
        request.HeaderOrigin.Id = item.Id;
      }

      return request.HeaderOrigin;
    }
  }
}
