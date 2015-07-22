using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Parameter.Activity
{
  public class ActivitiesService : Service
  {
    public object Get(Activities request)
    {
      ActivitiesResponse response = new ActivitiesResponse();

      if (!request.Ids.Any())
      {
        response.Activities.AddRange(Datas.Instance.DataStorage.Activities);
      }
      else
      {
        response.Activities.AddRange(Datas.Instance.DataStorage.Activities.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(Activities request)
    {
      if (request.Activity.Id > 0)
      {
        Datas.Instance.DataStorage.Activities[request.Activity.Id] = request.Activity;
      }
      else
      {
        Datas.Instance.DataStorage.Activities.Add(request.Activity);
      }
      return request.Activity;
    }
  }
}
