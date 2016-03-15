using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Trade.HeaderStatus;
using Bm2s.Response.Common.Trade.HeaderStatusStep;
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
        items.AddRange(Datas.Instance.DataStorage.HeaderStatusSteps.Where(item =>
          (request.HeaderStatusChildId == 0 || item.HeaderStatusChildId == request.HeaderStatusChildId) &&
          (request.HeaderStatusParentId == 0 || item.HeaderStatusParentId == request.HeaderStatusParentId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.HeaderStatusSteps.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Trade.HeaderStatusStep()
                        {
                          HeaderStatusChild = new HeaderStatusesService().Get(new HeaderStatuses() { Ids = new List<int>() { item.HeaderStatusChildId } }).HeaderStatuses.FirstOrDefault(),
                          HeaderStatusParent = new HeaderStatusesService().Get(new HeaderStatuses() { Ids = new List<int>() { item.HeaderStatusParentId } }).HeaderStatuses.FirstOrDefault(),
                          Id = item.Id
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.HeaderStatusSteps.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.HeaderStatusSteps.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.HeaderStatusSteps.Count + (collection.Count() % response.HeaderStatusSteps.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public HeaderStatusStepsResponse Post(HeaderStatusSteps request)
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

      HeaderStatusStepsResponse response = new HeaderStatusStepsResponse();
      response.HeaderStatusSteps.Add(request.HeaderStatusStep);
      return response;
    }

    public HeaderStatusStepsResponse Delete(HeaderStatusSteps request)
    {
      Bm2s.Data.Common.BLL.Trade.HeaderStatusStep item = Datas.Instance.DataStorage.HeaderStatusSteps.FirstOrDefault(nomenclature => nomenclature.Id == request.HeaderStatusStep.Id);
      if (item != null)
      {
        Datas.Instance.DataStorage.HeaderStatusSteps.Remove(item);
      }

      HeaderStatusStepsResponse response = new HeaderStatusStepsResponse();
      response.HeaderStatusSteps.Add(request.HeaderStatusStep);
      return response;
    }
  }
}
