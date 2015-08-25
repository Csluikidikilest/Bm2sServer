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
      List<Bm2s.Data.Common.BLL.Article.Subscription> items = new List<Data.Common.BLL.Article.Subscription>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Subscriptions.Where(item =>
          (request.ArticleId == 0 || item.ArticleId == request.ArticleId) &&
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Designation) || item.Code.ToLower().Contains(request.Designation.ToLower())) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Subscriptions.Where(item => request.Ids.Contains(item.Id)));
      }

      response.Subscriptions.AddRange(from item in items
                                      select new Bm2s.Poco.Common.Article.Subscription()
                                      {
                                        Article = new ArticlesService().Get(new Articles() { Ids = new List<int>() { item.ArticleId } }).Articles.FirstOrDefault(),
                                        Code = item.Code,
                                        Designation = item.Designation,
                                        EndingDate = item.EndingDate,
                                        Id = item.Id,
                                        Period = new PeriodsService().Get(new Periods() { Ids = new List<int>() { item.PeriodId } }).Periods.FirstOrDefault(),
                                        StartingDate = item.StartingDate
                                      });

      return response;
    }

    public SubscriptionsResponse Post(Subscriptions request)
    {
      if (request.Subscription.Id > 0)
      {
        Bm2s.Data.Common.BLL.Article.Subscription item = Datas.Instance.DataStorage.Subscriptions[request.Subscription.Id];
        item.ArticleId = request.Subscription.Article.Id;
        item.Code = request.Subscription.Code;
        item.Designation = request.Subscription.Designation;
        item.EndingDate = request.Subscription.EndingDate;
        item.PeriodId = request.Subscription.Period.Id;
        item.StartingDate = request.Subscription.StartingDate;
      }
      else
      {
        Bm2s.Data.Common.BLL.Article.Subscription item = new Data.Common.BLL.Article.Subscription()
        {
          ArticleId = request.Subscription.Article.Id,
          Code = request.Subscription.Code,
          Designation = request.Subscription.Designation,
          EndingDate = request.Subscription.EndingDate,
          PeriodId = request.Subscription.Period.Id,
          StartingDate = request.Subscription.StartingDate
        };

        Datas.Instance.DataStorage.Subscriptions.Add(item);
        request.Subscription.Id = item.Id;
      }

      SubscriptionsResponse response = new SubscriptionsResponse();
      response.Subscriptions.Add(request.Subscription);
      return response;
    }
  }
}
