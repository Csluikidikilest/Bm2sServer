using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Parameter.Affair;
using Bm2s.Response.Common.Parameter.AffairHeader;
using Bm2s.Response.Common.Trade.Header;
using Bm2s.Services.Common.Parameter.Affair;
using Bm2s.Services.Common.Trade.Header;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.AffairHeader
{
  class AffairHeadersService : Service
  {
    public AffairHeadersResponse Get(AffairHeaders request)
    {
      AffairHeadersResponse response = new AffairHeadersResponse();
      List<Bm2s.Data.Common.BLL.Parameter.Afhe> items = new List<Data.Common.BLL.Parameter.Afhe>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.AffairHeaders.Where(item =>
          (request.AffairId == 0 || item.AffaId == request.AffairId) &&
          (request.HeaderId == 0 || item.HeadId == request.HeaderId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.AffairHeaders.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Parameter.AffairHeader()
                        {
                          Affair = new AffairsService().Get(new Affairs() { Ids = new List<int>() { item.AffaId } }).Affairs.FirstOrDefault(),
                          Header = new HeadersService().Get(new Headers() { Ids = new List<int>() { item.HeadId } }).Headers.FirstOrDefault(),
                          Id = item.Id
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.AffairHeaders.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.AffairHeaders.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.AffairHeaders.Count + (collection.Count() % response.AffairHeaders.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public AffairHeadersResponse Post(AffairHeaders request)
    {
      if (request.AffairHeader.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.Afhe item = Datas.Instance.DataStorage.AffairHeaders[request.AffairHeader.Id];
        item.AffaId = request.AffairHeader.Affair.Id;
        item.HeadId = request.AffairHeader.Header.Id;
        Datas.Instance.DataStorage.AffairHeaders[request.AffairHeader.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.Afhe item = new Data.Common.BLL.Parameter.Afhe()
        {
          AffaId = request.AffairHeader.Affair.Id,
          HeadId = request.AffairHeader.Header.Id
        };

        Datas.Instance.DataStorage.AffairHeaders.Add(item);
        request.AffairHeader.Id = item.Id;
      }

      AffairHeadersResponse response = new AffairHeadersResponse();
      response.AffairHeaders.Add(request.AffairHeader);
      return response;
    }

    public AffairHeadersResponse Delete(AffairHeaders request)
    {
      Bm2s.Data.Common.BLL.Parameter.Afhe item = Datas.Instance.DataStorage.AffairHeaders[request.AffairHeader.Id];
      Datas.Instance.DataStorage.AffairHeaders.Remove(item);

      AffairHeadersResponse response = new AffairHeadersResponse();
      response.AffairHeaders.Add(request.AffairHeader);
      return response;
    }
  }
}
