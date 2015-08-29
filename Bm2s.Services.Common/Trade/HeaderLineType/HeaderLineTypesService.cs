using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Trade.HeaderLineType;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Trade.HeaderLineType
{
  public class HeaderLineTypesService : Service
  {
    public HeaderLineTypesResponse Get(HeaderLineTypes request)
    {
      HeaderLineTypesResponse response = new HeaderLineTypesResponse();
      List<Bm2s.Data.Common.BLL.Trade.HeaderLineType> items = new List<Data.Common.BLL.Trade.HeaderLineType>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.HeaderLineTypes.Where(item =>
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower())) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.HeaderLineTypes.Where(item => request.Ids.Contains(item.Id)));
      }

      response.HeaderLineTypes.AddRange((from item in items
                                        select new Bm2s.Poco.Common.Trade.HeaderLineType()
                                        {
                                          EndingDate = item.EndingDate,
                                          Id = item.Id,
                                          Name = item.Name,
                                          StartingDate = item.StartingDate
                                        }).AsQueryable().OrderBy(request.Order, request.AscendingOrder).Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));

      return response;
    }

    public HeaderLineTypesResponse Post(HeaderLineTypes request)
    {
      if (request.HeaderLineType.Id > 0)
      {
        Bm2s.Data.Common.BLL.Trade.HeaderLineType item = Datas.Instance.DataStorage.HeaderLineTypes[request.HeaderLineType.Id];
        item.EndingDate = request.HeaderLineType.EndingDate;
        item.Name = request.HeaderLineType.Name;
        item.StartingDate = request.HeaderLineType.StartingDate;
        Datas.Instance.DataStorage.HeaderLineTypes[request.HeaderLineType.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Trade.HeaderLineType item = new Data.Common.BLL.Trade.HeaderLineType()
        {
          EndingDate = request.HeaderLineType.EndingDate,
          Name = request.HeaderLineType.Name,
          StartingDate = request.HeaderLineType.StartingDate
        };

        Datas.Instance.DataStorage.HeaderLineTypes.Add(item);
        request.HeaderLineType.Id = item.Id;
      }

      HeaderLineTypesResponse response = new HeaderLineTypesResponse();
      response.HeaderLineTypes.Add(request.HeaderLineType);
      return response;
    }
  }
}