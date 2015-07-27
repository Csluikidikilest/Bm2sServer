using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Trade.HeaderLine
{
  public class HeaderLinesService : Service
  {
    public object Get(HeaderLines request)
    {
      HeaderLinesResponse response = new HeaderLinesResponse();

      if (!request.Ids.Any())
      {
        response.HeaderLines.AddRange(Datas.Instance.DataStorage.HeaderLines);
      }
      else
      {
        response.HeaderLines.AddRange(Datas.Instance.DataStorage.HeaderLines.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(HeaderLines request)
    {
      if (request.HeaderLine.Id > 0)
      {
        Datas.Instance.DataStorage.HeaderLines[request.HeaderLine.Id] = request.HeaderLine;
      }
      else
      {
        Datas.Instance.DataStorage.HeaderLines.Add(request.HeaderLine);
      }
      return request.HeaderLine;
    }
  }
}
