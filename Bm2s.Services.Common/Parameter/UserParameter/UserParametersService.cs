using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Parameter.UserParameter;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.UserParameter
{
  public class UserParametersService : Service
  {
    public UserParametersResponse Get(UserParameters request)
    {
      UserParametersResponse response = new UserParametersResponse();
      List<Bm2s.Data.Common.BLL.Parameter.UserParameter> items = new List<Data.Common.BLL.Parameter.UserParameter>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.UserParameters.Where(item =>
          (request.ParameterId == 0 || item.ParameterId == request.ParameterId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.UserParameters.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Parameter.UserParameter()
                        {
                          bValue = item.bValue,
                          dValue = item.dValue,
                          fValue = item.fValue,
                          Id = item.Id,
                          iValue = item.iValue,
                          sValue = item.sValue
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.UserParameters.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.UserParameters.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.UserParameters.Count + (collection.Count() % response.UserParameters.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public UserParametersResponse Post(UserParameters request)
    {
      if (request.UserParameter.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.UserParameter item = Datas.Instance.DataStorage.UserParameters[request.UserParameter.Id];
        item.bValue = request.UserParameter.bValue;
        item.dValue = request.UserParameter.dValue;
        item.fValue = request.UserParameter.fValue;
        item.iValue = request.UserParameter.iValue;
        item.sValue = request.UserParameter.sValue;
        Datas.Instance.DataStorage.UserParameters[request.UserParameter.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.UserParameter item = new Data.Common.BLL.Parameter.UserParameter()
        {
          bValue = request.UserParameter.bValue,
          dValue = request.UserParameter.dValue,
          fValue = request.UserParameter.fValue,
          iValue = request.UserParameter.iValue,
          sValue = request.UserParameter.sValue,
        };

        Datas.Instance.DataStorage.UserParameters.Add(item);
        request.UserParameter.Id = item.Id;
      }

      UserParametersResponse response = new UserParametersResponse();
      response.UserParameters.Add(request.UserParameter);
      return response;
    }

    public UserParametersResponse Delete(UserParameters request)
    {
      Bm2s.Data.Common.BLL.Parameter.Parameter item = Datas.Instance.DataStorage.Parameters[request.UserParameter.Id];
      Datas.Instance.DataStorage.Parameters.Remove(item);

      UserParametersResponse response = new UserParametersResponse();
      response.UserParameters.Add(request.UserParameter);
      return response;
    }
  }
}
