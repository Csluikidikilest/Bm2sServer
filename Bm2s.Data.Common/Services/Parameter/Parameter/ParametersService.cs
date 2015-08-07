using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Parameter.Parameter
{
  public class ParametersService : Service
  {
    public object Get(Parameters request)
    {
      ParametersResponse response = new ParametersResponse();

      if (!request.Ids.Any())
      {
        response.Parameters.AddRange(Datas.Instance.DataStorage.Parameters.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower()))
          ));
      }
      else
      {
        response.Parameters.AddRange(Datas.Instance.DataStorage.Parameters.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(Parameters request)
    {
      if (request.Parameter.Id > 0)
      {
        Datas.Instance.DataStorage.Parameters[request.Parameter.Id] = request.Parameter;
      }
      else
      {
        Datas.Instance.DataStorage.Parameters.Add(request.Parameter);
      }
      return request.Parameter;
    }
  }
}
