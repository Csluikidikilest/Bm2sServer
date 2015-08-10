﻿using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.UnitConversion
{
  public class UnitConversionsService : Service
  {
    public object Get(UnitConversions request)
    {
      UnitConversionsResponse response = new UnitConversionsResponse();

      if (!request.Ids.Any())
      {
        response.UnitConversions.AddRange(Datas.Instance.DataStorage.UnitConversions.Where(item =>
          (request.ChildId == 0 || item.ChildId == request.ChildId) &&
          (request.ParentId == 0 || item.ParentId == request.ParentId)
          ));
      }
      else
      {
        response.UnitConversions.AddRange(Datas.Instance.DataStorage.UnitConversions.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(UnitConversions request)
    {
      if (request.UnitConversion.Id > 0)
      {
        Datas.Instance.DataStorage.UnitConversions[request.UnitConversion.Id] = request.UnitConversion;
      }
      else
      {
        Datas.Instance.DataStorage.UnitConversions.Add(request.UnitConversion);
      }
      return request.UnitConversion;
    }
  }
}
