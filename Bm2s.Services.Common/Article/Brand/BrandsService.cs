using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System.Linq;
using System.Collections.Generic;
using Bm2s.Response.Common.Article.Brand;

namespace Bm2s.Services.Common.Article.Brand
{
  public class BrandsService : Service
  {
    public BrandsResponse Get(Brands request)
    {
      BrandsResponse response = new BrandsResponse();
      List<Bm2s.Data.Common.BLL.Article.Brand> items = new List<Data.Common.BLL.Article.Brand>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Brands.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower())) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Brands.Where(item => request.Ids.Contains(item.Id)));
      }

      response.Brands.AddRange(from item in items
                               select new Bm2s.Poco.Common.Article.Brand()
                               {
                                 Code = item.Code,
                                 EndingDate = item.EndingDate,
                                 Id = item.Id,
                                 Name = item.Name,
                                 StartingDate = item.StartingDate
                               });

      return response;
    }

    public BrandsResponse Post(Brands request)
    {
      if (request.Brand.Id > 0)
      {
        Bm2s.Data.Common.BLL.Article.Brand item = Datas.Instance.DataStorage.Brands[request.Brand.Id];
        item.Code = request.Brand.Code;
        item.EndingDate = request.Brand.EndingDate;
        item.Name = request.Brand.Name;
        item.StartingDate = request.Brand.StartingDate;
        Datas.Instance.DataStorage.Brands[request.Brand.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Article.Brand item = new Data.Common.BLL.Article.Brand()
        {
          Code = request.Brand.Code,
          EndingDate = request.Brand.EndingDate,
          Name = request.Brand.Name,
          StartingDate = request.Brand.StartingDate
        };

        Datas.Instance.DataStorage.Brands.Add(item);
        request.Brand.Id = item.Id;
      }

      BrandsResponse response = new BrandsResponse();
      response.Brands.Add(request.Brand);
      return response;
    }
  }
}
