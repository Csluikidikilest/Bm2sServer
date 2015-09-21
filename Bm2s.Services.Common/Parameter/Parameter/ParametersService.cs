using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Parameter.Parameter;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.Parameter
{
  public class ParametersService : Service
  {
    public ParametersResponse Get(Parameters request)
    {
      ParametersResponse response = new ParametersResponse();
      List<Bm2s.Data.Common.BLL.Parameter.Parameter> items = new List<Data.Common.BLL.Parameter.Parameter>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Parameters.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower()))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Parameters.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Parameter.Parameter()
                        {
                          bValue = item.bValue,
                          Code = item.Code,
                          dValue = item.dValue,
                          fValue = item.fValue,
                          Id = item.Id,
                          iValue = item.iValue,
                          sValue = item.sValue,
                          ValueType = item.ValueType
                        }).AsQueryable().OrderBy(request.Order, request.AscendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.Parameters.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.Parameters.AddRange(collection);
      }
      response.PagesCount = collection.Count() / response.Parameters.Count + (collection.Count() % response.Parameters.Count > 0 ? 1 : 0);

      return response;
    }

    public ParametersResponse Post(Parameters request)
    {
      if (request.Parameter.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.Parameter item = Datas.Instance.DataStorage.Parameters[request.Parameter.Id];
        item.bValue = request.Parameter.bValue;
        item.Code = request.Parameter.Code;
        item.dValue = request.Parameter.dValue;
        item.fValue = request.Parameter.fValue;
        item.iValue = request.Parameter.iValue;
        item.sValue = request.Parameter.sValue;
        item.ValueType = request.Parameter.ValueType;
        Datas.Instance.DataStorage.Parameters[request.Parameter.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.Parameter item = new Data.Common.BLL.Parameter.Parameter() {
        bValue = request.Parameter.bValue,
        Code = request.Parameter.Code,
        dValue = request.Parameter.dValue,
        fValue = request.Parameter.fValue,
        iValue = request.Parameter.iValue,
        sValue = request.Parameter.sValue,
        ValueType = request.Parameter.ValueType
        };

        Datas.Instance.DataStorage.Parameters.Add(item);
        request.Parameter.Id = item.Id;
      }

      ParametersResponse response = new ParametersResponse();
      response.Parameters.Add(request.Parameter);
      return response;
    }
  }
}
