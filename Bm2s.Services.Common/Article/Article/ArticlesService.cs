using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System.Linq;
using System.Collections.Generic;

namespace Bm2s.Services.Common.Article.Article
{
  public class ArticlesService : Service
  {
    public ArticlesResponse Get(Articles request)
    {
      ArticlesResponse response = new ArticlesResponse();
      List<Bm2s.Data.Common.BLL.Article.Article> articles = new List<Data.Common.BLL.Article.Article>();
      if (!request.Ids.Any())
      {
        articles.AddRange(Datas.Instance.DataStorage.Articles.Where(item =>
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
        articles.AddRange(Datas.Instance.DataStorage.Articles.Where(item => request.Ids.Contains(item.Id)));
      }

      response.Articles.AddRange(from item in articles
                                 select new Bm2s.Poco.Common.Article.Article()
                                 {
                                   Code = item.Code,
                                   Description = item.Description,
                                   Designation = item.Designation,
                                   EndingDate = item.EndingDate,
                                   Id = item.Id,
                                   Observation = item.Observation,
                                   StartingDate = item.StartingDate
                                 });
      return response;
    }

    public object Post(Articles request)
    {
      if (request.Article.Id > 0)
      {
        Datas.Instance.DataStorage.Articles[request.Article.Id].ArticleFamilyId = request.Article.ArticleFamily.Id;
        Datas.Instance.DataStorage.Articles[request.Article.Id].ArticleSubFamilyId = request.Article.ArticleSubFamily.Id;
        Datas.Instance.DataStorage.Articles[request.Article.Id].BrandId = request.Article.Brand.Id;
        Datas.Instance.DataStorage.Articles[request.Article.Id].Code = request.Article.Code;
        Datas.Instance.DataStorage.Articles[request.Article.Id].Description = request.Article.Description;
        Datas.Instance.DataStorage.Articles[request.Article.Id].Designation = request.Article.Designation;
        Datas.Instance.DataStorage.Articles[request.Article.Id].EndingDate = request.Article.EndingDate;
        Datas.Instance.DataStorage.Articles[request.Article.Id].Observation = request.Article.Observation;
        Datas.Instance.DataStorage.Articles[request.Article.Id].StartingDate = request.Article.StartingDate;
        Datas.Instance.DataStorage.Articles[request.Article.Id].UnitId = request.Article.Unit.Id;
      }
      else
      {
        Bm2s.Data.Common.BLL.Article.Article article = new Bm2s.Data.Common.BLL.Article.Article()
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

        Datas.Instance.DataStorage.Articles.Add(article);
        request.Article.Id = article.Id;
      }
      return request.Article;
    }
  }
}
