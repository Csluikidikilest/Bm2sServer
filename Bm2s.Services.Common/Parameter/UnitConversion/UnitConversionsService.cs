using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Services.Common.Parameter.Unit;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.UnitConversion
{
  public class UnitConversionsService : Service
  {
    public UnitConversionsResponse Get(UnitConversions request)
    {
      UnitConversionsResponse response = new UnitConversionsResponse();
      List<Bm2s.Data.Common.BLL.Parameter.UnitConversion> items = new List<Data.Common.BLL.Parameter.UnitConversion>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.UnitConversions.Where(item =>
          (request.ChildId == 0 || item.ChildId == request.ChildId) &&
          (request.ParentId == 0 || item.ParentId == request.ParentId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.UnitConversions.Where(item => request.Ids.Contains(item.Id)));
      }

      response.UnitConversions.AddRange(from item in items
                                        select new Bm2s.Poco.Common.Parameter.UnitConversion()
                                        {
                                          Child = new UnitsService().Get(new Units() { Ids = new List<int>() { item.ChildId } }).Units.FirstOrDefault(),
                                          Id = item.Id,
                                          Multiplier = item.Multiplier,
                                          Parent = new UnitsService().Get(new Units() { Ids = new List<int>() { item.ParentId } }).Units.FirstOrDefault(),
                                          Quantity = item.Quantity
                                        });

      return response;
    }

    public UnitConversionsResponse Post(UnitConversions request)
    {
      if (request.UnitConversion.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.UnitConversion item = Datas.Instance.DataStorage.UnitConversions[request.UnitConversion.Id];
        item.ChildId = request.UnitConversion.Child.Id;
        item.Multiplier = request.UnitConversion.Multiplier;
        item.ParentId = request.UnitConversion.Parent.Id;
        item.Quantity = request.UnitConversion.Quantity;
        Datas.Instance.DataStorage.UnitConversions[request.UnitConversion.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.UnitConversion item = new Data.Common.BLL.Parameter.UnitConversion()
        {
          ChildId = request.UnitConversion.Child.Id,
          Multiplier = request.UnitConversion.Multiplier,
          ParentId = request.UnitConversion.Parent.Id,
          Quantity = request.UnitConversion.Quantity
        };

        Datas.Instance.DataStorage.UnitConversions.Add(item);
        request.UnitConversion.Id = item.Id;
      }

      UnitConversionsResponse response = new UnitConversionsResponse();
      response.UnitConversions.Add(request.UnitConversion);
      return response;
    }
  }
}
