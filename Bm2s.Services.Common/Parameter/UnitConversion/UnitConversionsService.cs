using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Parameter.Unit;
using Bm2s.Response.Common.Parameter.UnitConversion;
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
          (request.ChildId == 0 || item.UnitChildId == request.ChildId) &&
          (request.ParentId == 0 || item.UnitParentId == request.ParentId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.UnitConversions.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Parameter.UnitConversion()
                        {
                          Child = new UnitsService().Get(new Units() { Ids = new List<int>() { item.UnitChildId } }).Units.FirstOrDefault(),
                          Id = item.Id,
                          Multiplier = item.Multiplier,
                          Parent = new UnitsService().Get(new Units() { Ids = new List<int>() { item.UnitParentId } }).Units.FirstOrDefault(),
                          Quantity = item.Quantity
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.UnitConversions.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.UnitConversions.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.UnitConversions.Count + (collection.Count() % response.UnitConversions.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public UnitConversionsResponse Post(UnitConversions request)
    {
      if (request.UnitConversion.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.UnitConversion item = Datas.Instance.DataStorage.UnitConversions[request.UnitConversion.Id];
        item.UnitChildId = request.UnitConversion.Child.Id;
        item.Multiplier = request.UnitConversion.Multiplier;
        item.UnitParentId = request.UnitConversion.Parent.Id;
        item.Quantity = request.UnitConversion.Quantity;
        Datas.Instance.DataStorage.UnitConversions[request.UnitConversion.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.UnitConversion item = new Data.Common.BLL.Parameter.UnitConversion()
        {
          UnitChildId = request.UnitConversion.Child.Id,
          Multiplier = request.UnitConversion.Multiplier,
          UnitParentId = request.UnitConversion.Parent.Id,
          Quantity = request.UnitConversion.Quantity
        };

        Datas.Instance.DataStorage.UnitConversions.Add(item);
        request.UnitConversion.Id = item.Id;
      }

      UnitConversionsResponse response = new UnitConversionsResponse();
      response.UnitConversions.Add(request.UnitConversion);
      return response;
    }

    public UnitConversionsResponse Delete(UnitConversions request)
    {
      Bm2s.Data.Common.BLL.Parameter.UnitConversion item = Datas.Instance.DataStorage.UnitConversions[request.UnitConversion.Id];
      Datas.Instance.DataStorage.UnitConversions.Remove(item);

      UnitConversionsResponse response = new UnitConversionsResponse();
      response.UnitConversions.Add(request.UnitConversion);
      return response;
    }
  }
}
