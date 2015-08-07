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
        response.Nomenclatures.AddRange(Datas.Instance.DataStorage.Nomenclatures.Where(item =>
          (request.ArticleId == 0 || item.ArticleChildId == request.ArticleId || item.ArticleParentId == request.ArticleId) &&
          (string.IsNullOrWhiteSpace(request.Code) || item.ArticleChild.Code.ToLower().Contains(request.Code.ToLower()) || item.ArticleParent.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Designation) || item.ArticleChild.Designation.ToLower().Contains(request.Designation.ToLower()) || item.ArticleParent.Designation.ToLower().Contains(request.Designation.ToLower()))
          ));
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
