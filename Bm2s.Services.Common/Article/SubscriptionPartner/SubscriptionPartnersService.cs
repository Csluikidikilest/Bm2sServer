﻿using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Article.Subscription;
using Bm2s.Response.Common.Article.SubscriptionPartner;
using Bm2s.Response.Common.Partner.Partner;
using Bm2s.Services.Common.Article.Subscription;
using Bm2s.Services.Common.Partner.Partner;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Article.SubscriptionPartner
{
  public class SubscriptionPartnersService : Service
  {
    public SubscriptionPartnersResponse Get(SubscriptionPartners request)
    {
      SubscriptionPartnersResponse response = new SubscriptionPartnersResponse();
      List<Bm2s.Data.Common.BLL.Article.SubscriptionPartner> items = new List<Data.Common.BLL.Article.SubscriptionPartner>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.SubscriptionPartners.Where(item =>
          (request.PartnerId == 0 || item.PartnerId == request.PartnerId) &&
          (request.SubscriptionId == 0 || item.SubscriptionId == request.SubscriptionId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.SubscriptionPartners.Where(item => request.Ids.Contains(item.Id)));
      }

      response.SubscriptionPartners.AddRange(from item in items
                                             select new Bm2s.Poco.Common.Article.SubscriptionPartner()
                                             {
                                               Id = item.Id,
                                               Partner = new PartnersService().Get(new Partners() { Ids = new List<int>() { item.PartnerId } }).Partners.FirstOrDefault(),
                                               Subscription = new SubscriptionsService().Get(new Subscriptions() { Ids = new List<int>() { item.SubscriptionId } }).Subscriptions.FirstOrDefault()
                                             });

      return response;
    }

    public SubscriptionPartnersResponse Post(SubscriptionPartners request)
    {
      if (request.SubscriptionPartner.Id > 0)
      {
        Bm2s.Data.Common.BLL.Article.SubscriptionPartner item = Datas.Instance.DataStorage.SubscriptionPartners[request.SubscriptionPartner.Id];
        item.PartnerId = request.SubscriptionPartner.Partner.Id;
        item.SubscriptionId = request.SubscriptionPartner.Subscription.Id;
      }
      else
      {
        Bm2s.Data.Common.BLL.Article.SubscriptionPartner item = new Data.Common.BLL.Article.SubscriptionPartner()
        {
          PartnerId = request.SubscriptionPartner.Partner.Id,
          SubscriptionId = request.SubscriptionPartner.Subscription.Id
        };

        Datas.Instance.DataStorage.SubscriptionPartners.Add(item);
        request.SubscriptionPartner.Id = item.Id;
      }

      SubscriptionPartnersResponse response = new SubscriptionPartnersResponse();
      response.SubscriptionPartners.Add(request.SubscriptionPartner);
      return response;
    }
  }
}
