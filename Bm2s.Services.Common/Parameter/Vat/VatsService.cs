using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Parameter.Vat;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.Vat
{
  public class VatsService : Service
  {
    public VatsResponse Get(Vats request)
    {
      VatsResponse response = new VatsResponse();
      List<Bm2s.Data.Common.BLL.Parameter.Vat> items = new List<Data.Common.BLL.Parameter.Vat>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Vats.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Vats.Where(item => request.Ids.Contains(item.Id)));
      }

      response.Vats.AddRange(from item in items
                             select new Bm2s.Poco.Common.Parameter.Vat()
                             {
                               AccountingEntry = item.AccountingEntry,
                               Code = item.Code,
                               EndingDate = item.EndingDate,
                               Id = item.Id,
                               Rate = item.Rate,
                               StartingDate = item.StartingDate
                             });

      return response;
    }

    public VatsResponse Post(Vats request)
    {
      if (request.Vat.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.Vat item = Datas.Instance.DataStorage.Vats[request.Vat.Id];
        item.AccountingEntry = request.Vat.AccountingEntry;
        item.Code = request.Vat.Code;
        item.EndingDate = request.Vat.EndingDate;
        item.Rate = request.Vat.Rate;
        item.StartingDate = request.Vat.StartingDate;
        Datas.Instance.DataStorage.Vats[request.Vat.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.Vat item = new Data.Common.BLL.Parameter.Vat()
        {
          AccountingEntry = request.Vat.AccountingEntry,
          Code = request.Vat.Code,
          EndingDate = request.Vat.EndingDate,
          Rate = request.Vat.Rate,
          StartingDate = request.Vat.StartingDate
        };

        Datas.Instance.DataStorage.Vats.Add(item);
        request.Vat.Id = item.Id;
      }

      VatsResponse response = new VatsResponse();
      response.Vats.Add(request.Vat);
      return response;
    }
  }
}
