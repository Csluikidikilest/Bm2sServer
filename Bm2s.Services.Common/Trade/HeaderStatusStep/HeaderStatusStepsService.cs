using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Services.Common.Trade.HeaderStatus;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Trade.HeaderStatusStep
{
  public class HeaderStatusStepsService : Service
  {
    public HeaderStatusStepsResponse Get(HeaderStatusSteps request)
    {
      HeaderStatusStepsResponse response = new HeaderStatusStepsResponse();
      List<Bm2s.Data.Common.BLL.Trade.HeaderStatusStep> items = new List<Data.Common.BLL.Trade.HeaderStatusStep>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.HeaderStatusSteps.Where(item=>
          (request.HeaderStatusChildId == 0 || item.HeaderStatusChildId == request.HeaderStatusChildId) &&
          (request.HeaderStatusParentId == 0 || item.HeaderStatusParentId == request.HeaderStatusParentId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.HeaderStatusSteps.Where(item => request.Ids.Contains(item.Id)));
      }

      response.HeaderStatusSteps.AddRange(from item in items
                                          select new Bm2s.Poco.Common.Trade.HeaderStatusStep()
                                          {
                                            HeaderStatusChild = new HeaderStatusesService().Get(new HeaderStatuses() { Ids = new List<int>() { item.HeaderStatusChildId } }).HeaderStatuses.FirstOrDefault(),
                                            HeaderStatusParent = new HeaderStatusesService().Get(new HeaderStatuses() { Ids = new List<int>() { item.HeaderStatusParentId } }).HeaderStatuses.FirstOrDefault(),
                                            Id = item.Id
                                          });

      return response;
    }

    public Bm2s.Poco.Common.Trade.HeaderStatusStep Post(HeaderStatusSteps request)
    {
      if (request.HeaderStatusStep.Id > 0)
      {
        Bm2s.Data.Common.BLL.Trade.HeaderStatusStep item = Datas.Instance.DataStorage.HeaderStatusSteps[request.HeaderStatusStep.Id];
        item.HeaderStatusChildId = request.HeaderStatusStep.HeaderStatusChild.Id;
        item.HeaderStatusParentId = request.HeaderStatusStep.HeaderStatusParent.Id;
        Datas.Instance.DataStorage.HeaderStatusSteps[request.HeaderStatusStep.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Trade.HeaderStatusStep item = new Data.Common.BLL.Trade.HeaderStatusStep()
        {
          HeaderStatusChildId = request.HeaderStatusStep.HeaderStatusChild.Id,
          HeaderStatusParentId = request.HeaderStatusStep.HeaderStatusParent.Id
        };

        Datas.Instance.DataStorage.HeaderStatusSteps.Add(item);
        request.HeaderStatusStep.Id = item.Id;
      }

      return request.HeaderStatusStep;
    }
  }
}
