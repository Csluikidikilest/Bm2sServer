using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
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
      List<Bm2s.Data.Common.BLL.Parameter.AffairHeader> items = new List<Data.Common.BLL.Parameter.AffairHeader>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.AffairHeaders.Where(item =>
          (request.AffairId == 0 || item.AffairId == request.AffairId) &&
          (request.HeaderId == 0 || item.HeaderId == request.HeaderId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.AffairHeaders.Where(item => request.Ids.Contains(item.Id)));
      }

      response.AffairHeaders.AddRange(from item in items
                                      select new Bm2s.Poco.Common.Parameter.AffairHeader()
                                      {
                                        Affair = new AffairsService().Get(new Affairs() { Ids = new List<int>() { item.AffairId } }).Affairs.FirstOrDefault(),
                                        Header = new HeadersService().Get(new Headers() { Ids = new List<int>() { item.HeaderId } }).Headers.FirstOrDefault(),
                                        Id = item.Id
                                      });

      return response;
    }

    public AffairHeadersResponse Post(AffairHeaders request)
    {
      if (request.AffairHeader.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.AffairHeader item = Datas.Instance.DataStorage.AffairHeaders[request.AffairHeader.Id];
        item.AffairId = request.AffairHeader.Affair.Id;
        item.HeaderId = request.AffairHeader.Header.Id;
        Datas.Instance.DataStorage.AffairHeaders[request.AffairHeader.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.AffairHeader item = new Data.Common.BLL.Parameter.AffairHeader()
        {
          AffairId = request.AffairHeader.Affair.Id,
          HeaderId = request.AffairHeader.Header.Id
        };

        Datas.Instance.DataStorage.AffairHeaders.Add(item);
        request.AffairHeader.Id = item.Id;
      }

      AffairHeadersResponse response = new AffairHeadersResponse();
      response.AffairHeaders.Add(request.AffairHeader);
      return response;
    }
  }
}
