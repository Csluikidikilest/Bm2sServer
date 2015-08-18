using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
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

      response.Parameters.AddRange(from item in items
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
                                   });

      return response;
    }

    public Bm2s.Poco.Common.Parameter.Parameter Post(Parameters request)
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

      return request.Parameter;
    }
  }
}
