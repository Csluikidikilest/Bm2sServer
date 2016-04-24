using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Article.Article;
using Bm2s.Response.Common.Article.Subscription;
using Bm2s.Response.Common.Parameter.Period;
using Bm2s.Services.Common.Article.Article;
using Bm2s.Services.Common.Parameter.Period;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Article.Subscription
{
  public class SubscriptionsService : Service
  {
    public SubscriptionsResponse Get(Subscriptions request)
    {
      SubscriptionsResponse response = new SubscriptionsResponse();
      List<Bm2s.Data.Common.BLL.Article.Subs> items = new List<Data.Common.BLL.Article.Subs>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Subscriptions.Where(item =>
          (request.ArticleId == 0 || item.ArtId == request.ArticleId) &&
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Designation) || item.Code.ToLower().Contains(request.Designation.ToLower())) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Subscriptions.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Article.Subscription()
                        {
                          Article = new ArticlesService().Get(new Articles() { Ids = new List<int>() { item.ArtId } }).Articles.FirstOrDefault(),
                          Code = item.Code,
                          Designation = item.Designation,
                          EndingDate = item.EndingDate,
                          Id = item.Id,
                          Period = new PeriodsService().Get(new Periods() { Ids = new List<int>() { item.PeriId } }).Periods.FirstOrDefault(),
                          StartingDate = item.StartingDate
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.Subscriptions.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.Subscriptions.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.Subscriptions.Count + (collection.Count() % response.Subscriptions.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public SubscriptionsResponse Post(Subscriptions request)
    {
      if (request.Subscription.Id > 0)
      {
        Bm2s.Data.Common.BLL.Article.Subs item = Datas.Instance.DataStorage.Subscriptions[request.Subscription.Id];
        item.ArtId = request.Subscription.Article.Id;
        item.Code = request.Subscription.Code;
        item.Designation = request.Subscription.Designation;
        item.EndingDate = request.Subscription.EndingDate;
        item.PeriId = request.Subscription.Period.Id;
        item.StartingDate = request.Subscription.StartingDate;
      }
      else
      {
        Bm2s.Data.Common.BLL.Article.Subs item = new Data.Common.BLL.Article.Subs()
        {
          ArtId = request.Subscription.Article.Id,
          Code = request.Subscription.Code,
          Designation = request.Subscription.Designation,
          EndingDate = request.Subscription.EndingDate,
          PeriId = request.Subscription.Period.Id,
          StartingDate = request.Subscription.StartingDate
        };

        Datas.Instance.DataStorage.Subscriptions.Add(item);
        request.Subscription.Id = item.Id;
      }

      SubscriptionsResponse response = new SubscriptionsResponse();
      response.Subscriptions.Add(request.Subscription);
      return response;
    }

    public SubscriptionsResponse Delete(Subscriptions request)
    {
      Bm2s.Data.Common.BLL.Article.Subs item = Datas.Instance.DataStorage.Subscriptions[request.Subscription.Id];
      Datas.Instance.DataStorage.Subscriptions.Remove(item);

      SubscriptionsResponse response = new SubscriptionsResponse();
      response.Subscriptions.Add(request.Subscription);
      return response;
    }
  }
}
