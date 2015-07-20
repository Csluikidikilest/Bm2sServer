using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System.Linq;

namespace Bm2s.Data.Common.Services.Article.Nomenclature
{
  public class NomenclaturesService : Service
  {
    public object Get(Nomenclatures request)
    {
      NomenclaturesResponse response = new NomenclaturesResponse();

      if (!request.Ids.Any())
      {
        response.Nomenclatures.AddRange(Datas.Instance.DataStorage.Nomenclatures);
      }
      else
      {
        response.Nomenclatures.AddRange(Datas.Instance.DataStorage.Nomenclatures.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(Nomenclatures request)
    {
      if (request.Nomenclature.Id > 0)
      {
        Datas.Instance.DataStorage.Nomenclatures[request.Nomenclature.Id] = request.Nomenclature;
      }
      else
      {
        Datas.Instance.DataStorage.Nomenclatures.Add(request.Nomenclature);
      }
      return request.Nomenclature;
    }
  }
}
