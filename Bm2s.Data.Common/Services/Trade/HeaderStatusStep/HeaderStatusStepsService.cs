using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Trade.HeaderStatusStep
{
  public class HeaderStatusStepsService : Service
  {
    public object Get(HeaderStatusSteps request)
    {
      HeaderStatusStepsResponse response = new HeaderStatusStepsResponse();

      if (!request.Ids.Any())
      {
        response.HeaderStatusSteps.AddRange(Datas.Instance.DataStorage.HeaderStatusSteps.Where(item=>
          (request.HeaderStatusChildId == 0 || item.HeaderStatusChildId == request.HeaderStatusChildId) &&
          (request.HeaderStatusParentId == 0 || item.HeaderStatusParentId == request.HeaderStatusParentId)
          ));
      }
      else
      {
        response.HeaderStatusSteps.AddRange(Datas.Instance.DataStorage.HeaderStatusSteps.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(HeaderStatusSteps request)
    {
      if (request.HeaderStatusStep.Id > 0)
      {
        Datas.Instance.DataStorage.HeaderStatusSteps[request.HeaderStatusStep.Id] = request.HeaderStatusStep;
      }
      else
      {
        Datas.Instance.DataStorage.HeaderStatusSteps.Add(request.HeaderStatusStep);
      }
      return request.HeaderStatusStep;
    }
  }
}
