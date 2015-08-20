﻿using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Services.Common.Trade.HeaderStatus;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Trade.HeaderFreeReference
{
  public class HeaderFreeReferencesService : Service
  {
    public HeaderFreeReferencesResponse Get(HeaderFreeReferences request)
    {
      HeaderFreeReferencesResponse response = new HeaderFreeReferencesResponse();
      List<Bm2s.Data.Common.BLL.Trade.HeaderFreeReference> items = new List<Data.Common.BLL.Trade.HeaderFreeReference>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.HeaderFreeReferences.Where(item =>
          (request.HeaderStatusId == 0 || item.HeaderStatusId == request.HeaderStatusId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.HeaderFreeReferences.Where(item => request.Ids.Contains(item.Id)));
      }

      response.HeaderFreeReferences.AddRange(from item in items
                                             select new Bm2s.Poco.Common.Trade.HeaderFreeReference()
                                             {
                                               HeaderStatus = new HeaderStatusesService().Get(new HeaderStatuses() { Ids = new List<int>() { item.HeaderStatusId} }).HeaderStatuses.FirstOrDefault(),
                                               Id = item.Id,
                                               Reference = item.Reference
                                             });

      return response;
    }

    public Bm2s.Poco.Common.Trade.HeaderFreeReference Post(HeaderFreeReferences request)
    {
      if (request.HeaderFreeReference.Id > 0)
      {
        Bm2s.Data.Common.BLL.Trade.HeaderFreeReference item = Datas.Instance.DataStorage.HeaderFreeReferences[request.HeaderFreeReference.Id];
        item.HeaderStatusId = request.HeaderFreeReference.HeaderStatus.Id;
        item.Reference = request.HeaderFreeReference.Reference;
        Datas.Instance.DataStorage.HeaderFreeReferences[request.HeaderFreeReference.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Trade.HeaderFreeReference item = new Data.Common.BLL.Trade.HeaderFreeReference()
        {
          HeaderStatusId = request.HeaderFreeReference.HeaderStatus.Id,
          Reference = request.HeaderFreeReference.Reference
        };

        Datas.Instance.DataStorage.HeaderFreeReferences.Add(item);
        request.HeaderFreeReference.Id = item.Id;
      }

      return request.HeaderFreeReference;
    }
  }
}
