using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Services.Common.Article.Brand;
using Bm2s.Services.Common.Parameter.Unit;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Article.Article
{
  public class ArticlesService : Service
  {
    public ArticlesResponse Get(Articles request)
    {
      ArticlesResponse response = new ArticlesResponse();
      List<Bm2s.Data.Common.BLL.Article.Article> items = new List<Data.Common.BLL.Article.Article>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Articles.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Designation) || item.Designation.ToLower().Contains(request.Designation.ToLower())) &&
          (request.ArticleFamilyId == 0 || item.ArticleFamilyId == request.ArticleFamilyId) &&
          (request.ArticleSubFamilyId == 0 || item.ArticleSubFamilyId == request.ArticleSubFamilyId) &&
          (request.BrandId == 0 || item.BrandId == request.BrandId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Articles.Where(item => request.Ids.Contains(item.Id)));
      }

      response.Articles.AddRange(from item in items
                                 select new Bm2s.Poco.Common.Article.Article()
                                 {
                                   ArticleFamily = new ArticleFamily.ArticleFamiliesService().Get(new ArticleFamily.ArticleFamilies() { Ids = new List<int>() { item.ArticleFamilyId } }).ArticleFamilies.FirstOrDefault(),
                                   ArticleSubFamily = new ArticleSubFamily.ArticleSubFamiliesService().Get(new ArticleSubFamily.ArticleSubFamilies() { Ids = new List<int>() { item.ArticleSubFamilyId } }).ArticleSubFamilies.FirstOrDefault(),
                                   Brand = new BrandsService().Get(new Brands(){Ids = new List<int>(){item.BrandId}}).Brands.FirstOrDefault(),
                                   Code = item.Code,
                                   Description = item.Description,
                                   Designation = item.Designation,
                                   EndingDate = item.EndingDate,
                                   Id = item.Id,
                                   Observation = item.Observation,
                                   StartingDate = item.StartingDate,
                                   Unit = new UnitsService().Get(new Units() { Ids = new List<int>() { item.UnitId} }).Units.FirstOrDefault()
                                 });
      return response;
    }

    public ArticlesResponse Post(Articles request)
    {
      if (request.Article.Id > 0)
      {
        Bm2s.Data.Common.BLL.Article.Article item = Datas.Instance.DataStorage.Articles[request.Article.Id];
        item.ArticleFamilyId = request.Article.ArticleFamily.Id;
        item.ArticleSubFamilyId = request.Article.ArticleSubFamily.Id;
        item.BrandId = request.Article.Brand.Id;
        item.Code = request.Article.Code;
        item.Description = request.Article.Description;
        item.Designation = request.Article.Designation;
        item.EndingDate = request.Article.EndingDate;
        item.Observation = request.Article.Observation;
        item.StartingDate = request.Article.StartingDate;
        item.UnitId = request.Article.Unit.Id;
        Datas.Instance.DataStorage.Articles[request.Article.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Article.Article item = new Bm2s.Data.Common.BLL.Article.Article()
        {
          ArticleFamilyId = request.Article.ArticleFamily.Id,
          ArticleSubFamilyId = request.Article.ArticleSubFamily.Id,
          BrandId = request.Article.Brand.Id,
          Code = request.Article.Code,
          Description = request.Article.Description,
          Designation = request.Article.Designation,
          EndingDate = request.Article.EndingDate,
          Observation = request.Article.Observation,
          StartingDate = request.Article.StartingDate,
          UnitId = request.Article.Unit.Id
        };

        Datas.Instance.DataStorage.Articles.Add(item);
        request.Article.Id = item.Id;
      }

      ArticlesResponse response = new ArticlesResponse();
      response.Articles.Add(request.Article);
      return response;
    }
  }
}
