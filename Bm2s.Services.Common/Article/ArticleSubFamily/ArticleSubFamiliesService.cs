using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System.Linq;
using System.Collections.Generic;
using Bm2s.Services.Common.Article.ArticleFamily;
using Bm2s.Response.Common.Article.ArticleSubFamily;
using Bm2s.Response.Common.Article.ArticleFamily;

namespace Bm2s.Services.Common.Article.ArticleSubFamily
{
  public class ArticleSubFamiliesService : Service
  {
    public ArticleSubFamiliesResponse Get(ArticleSubFamilies request)
    {
      ArticleSubFamiliesResponse response = new ArticleSubFamiliesResponse();
      List<Bm2s.Data.Common.BLL.Article.ArticleSubFamily> items = new List<Data.Common.BLL.Article.ArticleSubFamily>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleSubFamilies.Where(item =>
          (string.IsNullOrWhiteSpace(request.AccountingEntry) || item.AccountingEntry.ToLower().Contains(request.AccountingEntry.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Designation) || item.Designation.ToLower().Contains(request.Designation.ToLower())) &&
          (request.ArticleFamilyId == 0 || item.ArticleFamilyId == request.ArticleFamilyId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleSubFamilies.Where(item => request.Ids.Contains(item.Id)));
      }

      response.ArticleSubFamilies.AddRange((from item in items
                                           select new Bm2s.Poco.Common.Article.ArticleSubFamily()
                                           {
                                             AccountingEntry = item.AccountingEntry,
                                             ArticleFamily = new ArticleFamiliesService().Get(new ArticleFamilies() { Ids = new List<int>() { item.ArticleFamilyId } }).ArticleFamilies.FirstOrDefault(),
                                             Code = item.Code,
                                             Description = item.Description,
                                             Designation = item.Designation,
                                             EndingDate = item.EndingDate,
                                             Id = item.Id,
                                             StartingDate = item.StartingDate
                                           }).AsQueryable().OrderBy(request.Order, request.AscendingOrder).Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));

      return response;
    }

    public ArticleSubFamiliesResponse Post(ArticleSubFamilies request)
    {
      if (request.ArticleSubFamily.Id > 0)
      {
        Bm2s.Data.Common.BLL.Article.ArticleSubFamily item = Datas.Instance.DataStorage.ArticleSubFamilies[request.ArticleSubFamily.Id];
        item.AccountingEntry = request.ArticleSubFamily.AccountingEntry;
        item.ArticleFamilyId = request.ArticleSubFamily.ArticleFamily.Id;
        item.Code = request.ArticleSubFamily.Code;
        item.Description = request.ArticleSubFamily.Description;
        item.Designation = request.ArticleSubFamily.Designation;
        item.EndingDate = request.ArticleSubFamily.EndingDate;
        item.StartingDate = request.ArticleSubFamily.StartingDate;
        Datas.Instance.DataStorage.ArticleSubFamilies[request.ArticleSubFamily.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Article.ArticleSubFamily item = new Data.Common.BLL.Article.ArticleSubFamily()
        {
          AccountingEntry = request.ArticleSubFamily.AccountingEntry,
          ArticleFamilyId = request.ArticleSubFamily.ArticleFamily.Id,
          Code = request.ArticleSubFamily.Code,
          Description = request.ArticleSubFamily.Description,
          Designation = request.ArticleSubFamily.Designation,
          EndingDate = request.ArticleSubFamily.EndingDate,
          StartingDate = request.ArticleSubFamily.StartingDate
        };

        Datas.Instance.DataStorage.ArticleSubFamilies.Add(item);
        request.ArticleSubFamily.Id = item.Id;
      }

      ArticleSubFamiliesResponse response = new ArticleSubFamiliesResponse();
      response.ArticleSubFamilies.Add(request.ArticleSubFamily);
      return response;
    }
  }
}
