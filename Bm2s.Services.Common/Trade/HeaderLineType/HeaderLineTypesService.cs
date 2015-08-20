using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Trade.HeaderLineType
{
  public class HeaderLineTypesService : Service
  {
    public HeaderLineTypesResponse Get(HeaderLineTypes request)
    {
      HeaderLineTypesResponse response = new HeaderLineTypesResponse();

      if (!request.Ids.Any())
      {
        response.HeaderLineTypes.AddRange(Datas.Instance.DataStorage.HeaderLineTypes.Where(item =>
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower())) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        response.HeaderLineTypes.AddRange(Datas.Instance.DataStorage.HeaderLineTypes.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(HeaderLineTypes request)
    {
      if (request.HeaderLineType.Id > 0)
      {
        Datas.Instance.DataStorage.HeaderLineTypes[request.HeaderLineType.Id] = request.HeaderLineType;
      }
      else
      {
        Datas.Instance.DataStorage.HeaderLineTypes.Add(request.HeaderLineType);
      }
      return request.HeaderLineType;
    }
  }
}