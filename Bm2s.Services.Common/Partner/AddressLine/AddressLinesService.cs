using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Partner.AddressLine
{
  class AddressLinesService : Service
  {
    public object Get(AddressLines request)
    {
      AddressLinesResponse response = new AddressLinesResponse();

      if (!request.Ids.Any())
      {
        response.AddressLines.AddRange(Datas.Instance.DataStorage.AddressLines.Where(item =>
          (request.AddressId == 0 || item.AddressId == request.AddressId)
          ));
      }
      else
      {
        response.AddressLines.AddRange(Datas.Instance.DataStorage.AddressLines.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(AddressLines request)
    {
      if (request.AddressLine.Id > 0)
      {
        Datas.Instance.DataStorage.AddressLines[request.AddressLine.Id] = request.AddressLine;
      }
      else
      {
        Datas.Instance.DataStorage.AddressLines.Add(request.AddressLine);
      }
      return request.AddressLine;
    }
  }
}
