using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Trade.Header;
using Bm2s.Response.Common.Trade.HeaderOrigin;
using Bm2s.Services.Common.Trade.Header;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Trade.HeaderOrigin
{
  public class HeaderOriginsService : Service
  {
    public HeaderOriginsResponse Get(HeaderOrigins request)
    {
      HeaderOriginsResponse response = new HeaderOriginsResponse();
      List<Bm2s.Data.Common.BLL.Trade.Heor> items = new List<Data.Common.BLL.Trade.Heor>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.HeaderOrigins.Where(item =>
          (request.HeaderChildId == 0 || item.HechId == request.HeaderChildId) &&
          (request.HeaderParentId == 0 || item.HepaId == request.HeaderParentId) &&
          (!request.Date.HasValue || request.Date >= item.Date)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.HeaderOrigins.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Trade.HeaderOrigin()
                        {
                          Date = item.Date,
                          HeaderChild = new HeadersService().Get(new Headers() { Ids = new List<int>() { item.HechId } }).Headers.FirstOrDefault(),
                          HeaderParent = new HeadersService().Get(new Headers() { Ids = new List<int>() { item.HepaId } }).Headers.FirstOrDefault(),
                          Id = item.Id
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.HeaderOrigins.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.HeaderOrigins.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.HeaderOrigins.Count + (collection.Count() % response.HeaderOrigins.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public HeaderOriginsResponse Post(HeaderOrigins request)
    {
      if (request.HeaderOrigin.Id > 0)
      {
        Bm2s.Data.Common.BLL.Trade.Heor item = Datas.Instance.DataStorage.HeaderOrigins[request.HeaderOrigin.Id];
        item.Date = request.HeaderOrigin.Date;
        item.HechId = request.HeaderOrigin.HeaderChild.Id;
        item.HepaId = request.HeaderOrigin.HeaderParent.Id;
        Datas.Instance.DataStorage.HeaderOrigins[request.HeaderOrigin.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Trade.Heor item = new Data.Common.BLL.Trade.Heor()
        {
          Date = request.HeaderOrigin.Date,
          HechId = request.HeaderOrigin.HeaderChild.Id,
          HepaId = request.HeaderOrigin.HeaderParent.Id
        };

        Datas.Instance.DataStorage.HeaderOrigins.Add(item);
        request.HeaderOrigin.Id = item.Id;
      }

      HeaderOriginsResponse response = new HeaderOriginsResponse();
      response.HeaderOrigins.Add(request.HeaderOrigin);
      return response;
    }

    public HeaderOriginsResponse Delete(HeaderOrigins request)
    {
      Bm2s.Data.Common.BLL.Trade.Heor item = Datas.Instance.DataStorage.HeaderOrigins[request.HeaderOrigin.Id];
      Datas.Instance.DataStorage.HeaderOrigins.Remove(item);

      HeaderOriginsResponse response = new HeaderOriginsResponse();
      response.HeaderOrigins.Add(request.HeaderOrigin);
      return response;
    }
  }
}
