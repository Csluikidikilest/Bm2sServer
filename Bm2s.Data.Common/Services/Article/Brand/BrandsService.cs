using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System.Linq;

namespace Bm2s.Data.Common.Services.Article.Brand
{
  public class BrandsService : Service
  {
    public object Get(Brands request)
    {
      BrandsResponse response = new BrandsResponse();

      if (!request.Ids.Any())
      {
        response.Brands.AddRange(Datas.Instance.DataStorage.Brands);
      }
      else
      {
        response.Brands.AddRange(Datas.Instance.DataStorage.Brands.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(Brands request)
    {
      if (request.Brand.Id > 0)
      {
        Datas.Instance.DataStorage.Brands[request.Brand.Id] = request.Brand;
      }
      else
      {
        Datas.Instance.DataStorage.Brands.Add(request.Brand);
      }
      return request.Brand;
    }
  }
}
