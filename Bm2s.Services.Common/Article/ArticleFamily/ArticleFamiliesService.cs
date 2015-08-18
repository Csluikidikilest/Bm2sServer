﻿using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
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

      response.ArticleFamilies.AddRange(from item in items
                                        select new Bm2s.Poco.Common.Article.ArticleFamily()
                                        {
                                          AccountingEntry = item.AccountingEntry,
                                          Code = item.Code,
                                          Description = item.Description,
                                          Designation = item.Designation,
                                          EndingDate = item.EndingDate,
                                          Id = item.Id,
                                          StartingDate = item.StartingDate,
                                        });
      return response;
    }

    public Bm2s.Poco.Common.Article.ArticleFamily Post(ArticleFamilies request)
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
      return request.ArticleFamily;
    }
  }
}