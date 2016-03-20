using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System.Linq;
using System.Collections.Generic;
using Bm2s.Services.Common.Article.Article;
using Bm2s.Response.Common.Article.Nomenclature;
using Bm2s.Response.Common.Article.Article;
using System;

namespace Bm2s.Services.Common.Article.Nomenclature
{
  public class NomenclaturesService : Service
  {
    public NomenclaturesResponse Get(Nomenclatures request)
    {
      NomenclaturesResponse response = new NomenclaturesResponse();
      List<Bm2s.Data.Common.BLL.Article.Nomenclature> items = new List<Data.Common.BLL.Article.Nomenclature>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Nomenclatures.Where(item =>
          (request.ArticleId == 0 || item.ArticleChildId == request.ArticleId || item.ArticleParentId == request.ArticleId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Nomenclatures.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Article.Nomenclature()
                        {
                          ArticleChild = new ArticlesService().Get(new Articles() { Ids = new List<int>() { item.ArticleChildId } }).Articles.FirstOrDefault(),
                          ArticleParent = new ArticlesService().Get(new Articles() { Ids = new List<int>() { item.ArticleParentId } }).Articles.FirstOrDefault(),
                          BuyPrice = Convert.ToDecimal(item.BuyPrice),
                          Id = item.Id,
                          QuantityChild = item.QuantityChild,
                          QuantityParent = item.QuantityParent
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.Nomenclatures.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.Nomenclatures.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.Nomenclatures.Count + (collection.Count() % response.Nomenclatures.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public NomenclaturesResponse Post(Nomenclatures request)
    {
      if (request.Nomenclature.Id > 0)
      {
        Bm2s.Data.Common.BLL.Article.Nomenclature item = Datas.Instance.DataStorage.Nomenclatures[request.Nomenclature.Id];
        item.ArticleChildId = request.Nomenclature.ArticleChild.Id;
        item.ArticleParentId = request.Nomenclature.ArticleParent.Id;
        item.BuyPrice = Convert.ToDouble(request.Nomenclature.BuyPrice);
        item.EndingDate = request.Nomenclature.EndingDate;
        item.QuantityChild = request.Nomenclature.QuantityChild;
        item.QuantityParent = request.Nomenclature.QuantityParent;
        item.StartingDate = request.Nomenclature.StartingDate;
        Datas.Instance.DataStorage.Nomenclatures[request.Nomenclature.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Article.Nomenclature item = new Data.Common.BLL.Article.Nomenclature()
        {
          ArticleChildId = request.Nomenclature.ArticleChild.Id,
          ArticleParentId = request.Nomenclature.ArticleParent.Id,
          BuyPrice = Convert.ToDouble(request.Nomenclature.BuyPrice),
          EndingDate = request.Nomenclature.EndingDate,
          QuantityChild = request.Nomenclature.QuantityChild,
          QuantityParent = request.Nomenclature.QuantityParent,
          StartingDate = request.Nomenclature.StartingDate
        };

        Datas.Instance.DataStorage.Nomenclatures.Add(item);
        request.Nomenclature.Id = item.Id;
      }

      NomenclaturesResponse response = new NomenclaturesResponse();
      response.Nomenclatures.Add(request.Nomenclature);
      return response;
    }

    public NomenclaturesResponse Delete(Nomenclatures request)
    {
      Bm2s.Data.Common.BLL.Article.Nomenclature item = Datas.Instance.DataStorage.Nomenclatures[request.Nomenclature.Id];
      item.EndingDate = DateTime.Now;
      Datas.Instance.DataStorage.Nomenclatures[item.Id] = item;

      NomenclaturesResponse response = new NomenclaturesResponse();
      response.Nomenclatures.Add(request.Nomenclature);
      return response;
    }
  }
}
