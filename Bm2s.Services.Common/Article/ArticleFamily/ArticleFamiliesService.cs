using System;
using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Article.ArticleFamily;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Article.ArticleFamily
{
  public class ArticleFamiliesService : Service
  {
    public ArticleFamiliesResponse Get(ArticleFamilies request)
    {
      ArticleFamiliesResponse response = new ArticleFamiliesResponse();
      List<Bm2s.Data.Common.BLL.Article.ArticleFamily> items = new List<Data.Common.BLL.Article.ArticleFamily>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleFamilies.Where(item =>
          (string.IsNullOrWhiteSpace(request.AccountingEntry) || item.AccountingEntry.ToLower().Contains(request.AccountingEntry.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Designation) || item.Designation.ToLower().Contains(request.Designation.ToLower())) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleFamilies.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Article.ArticleFamily()
                        {
                          AccountingEntry = item.AccountingEntry,
                          Code = item.Code,
                          Description = item.Description,
                          Designation = item.Designation,
                          EndingDate = item.EndingDate,
                          Id = item.Id,
                          StartingDate = item.StartingDate,
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.ArticleFamilies.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.ArticleFamilies.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.ArticleFamilies.Count + (collection.Count() % response.ArticleFamilies.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public ArticleFamiliesResponse Post(ArticleFamilies request)
    {
      if (request.ArticleFamily.Id > 0)
      {
        Bm2s.Data.Common.BLL.Article.ArticleFamily item = Datas.Instance.DataStorage.ArticleFamilies[request.ArticleFamily.Id];
        item.AccountingEntry = request.ArticleFamily.AccountingEntry;
        item.Code = request.ArticleFamily.Code;
        item.Description = request.ArticleFamily.Description;
        item.Designation = request.ArticleFamily.Designation;
        item.EndingDate = request.ArticleFamily.EndingDate;
        item.StartingDate = request.ArticleFamily.StartingDate;
        Datas.Instance.DataStorage.ArticleFamilies[request.ArticleFamily.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Article.ArticleFamily item = new Bm2s.Data.Common.BLL.Article.ArticleFamily()
        {
          AccountingEntry = request.ArticleFamily.AccountingEntry,
          Code = request.ArticleFamily.Code,
          Description = request.ArticleFamily.Description,
          Designation = request.ArticleFamily.Designation,
          EndingDate = request.ArticleFamily.EndingDate,
          StartingDate = request.ArticleFamily.StartingDate,
        };

        Datas.Instance.DataStorage.ArticleFamilies.Add(item);
        request.ArticleFamily.Id = item.Id;
      }

      ArticleFamiliesResponse response = new ArticleFamiliesResponse();
      response.ArticleFamilies.Add(request.ArticleFamily);
      return response;
    }

    public ArticleFamiliesResponse Delete(ArticleFamilies request)
    {
      Bm2s.Data.Common.BLL.Article.ArticleFamily item = Datas.Instance.DataStorage.ArticleFamilies[request.ArticleFamily.Id];
      item.EndingDate = DateTime.Now;
      Datas.Instance.DataStorage.ArticleFamilies[item.Id] = item;

      ArticleFamiliesResponse response = new ArticleFamiliesResponse();
      response.ArticleFamilies.Add(request.ArticleFamily);
      return response;
    }
  }
}
