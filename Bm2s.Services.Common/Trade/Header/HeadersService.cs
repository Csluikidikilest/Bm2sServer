using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Parameter.Activity;
using Bm2s.Response.Common.Trade.Header;
using Bm2s.Response.Common.Trade.HeaderStatus;
using Bm2s.Response.Common.User.User;
using Bm2s.Services.Common.Parameter.Activity;
using Bm2s.Services.Common.Trade.HeaderStatus;
using Bm2s.Services.Common.User.User;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Trade.Header
{
  public class HeadersService : Service
  {
    public HeadersResponse Get(Headers request)
    {
      HeadersResponse response = new HeadersResponse();
      List<Bm2s.Data.Common.BLL.Trade.Header> items = new List<Data.Common.BLL.Trade.Header>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Headers.Where(item =>
          (request.ActivityId == 0 || item.ActivityId == request.ActivityId) &&
          (!request.Date.HasValue || (request.Date >= item.Date && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value))) &&
          (string.IsNullOrWhiteSpace(request.Description) || item.Description.ToLower().Contains(request.Description.ToLower())) &&
          (request.HeaderStatusId == 0 || item.HeaderStatusId == request.HeaderStatusId) &&
          (!request.IsSell || item.IsSell) &&
          (string.IsNullOrWhiteSpace(request.Reference) || item.Reference.ToLower().Contains(request.Reference.ToLower())) &&
          (request.UserId == 0 || item.UserId == request.UserId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Headers.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Trade.Header()
                        {
                          Activity = new ActivitiesService().Get(new Activities() { Ids = new List<int>() { item.ActivityId } }).Activities.FirstOrDefault(),
                          Date = item.Date,
                          DeliveryObservation = item.DeliveryObservation,
                          Description = item.Description,
                          EndingDate = item.EndingDate,
                          FooterDiscount = item.FooterDiscount,
                          HeaderStatus = new HeaderStatusesService().Get(new HeaderStatuses() { Ids = new List<int>() { item.HeaderStatusId } }).HeaderStatuses.FirstOrDefault(),
                          Id = item.Id,
                          IsSell = item.IsSell,
                          Reference = item.Reference,
                          User = new UsersService().Get(new Users() { Ids = new List<int>() { item.UserId } }).Users.FirstOrDefault()
                        }).AsQueryable().OrderBy(request.Order, request.AscendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.Headers.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.Headers.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.Headers.Count + (collection.Count() % response.Headers.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public HeadersResponse Post(Headers request)
    {
      if (request.Header.Id > 0)
      {
        Bm2s.Data.Common.BLL.Trade.Header item = Datas.Instance.DataStorage.Headers[request.Header.Id];
        item.ActivityId = request.Header.Activity.Id;
        item.Date = request.Header.Date;
        item.DeliveryObservation = request.Header.DeliveryObservation;
        item.Description = request.Header.Description;
        item.EndingDate = request.Header.EndingDate;
        item.FooterDiscount = request.Header.FooterDiscount;
        item.HeaderStatusId = request.Header.HeaderStatus.Id;
        item.IsSell = request.Header.IsSell;
        item.Reference = request.Header.Reference;
        item.UserId = request.Header.User.Id;
        Datas.Instance.DataStorage.Headers[request.Header.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Trade.Header item = new Data.Common.BLL.Trade.Header()
        {
          ActivityId = request.Header.Activity.Id,
          Date = request.Header.Date,
          DeliveryObservation = request.Header.DeliveryObservation,
          Description = request.Header.Description,
          EndingDate = request.Header.EndingDate,
          FooterDiscount = request.Header.FooterDiscount,
          HeaderStatusId = request.Header.HeaderStatus.Id,
          IsSell = request.Header.IsSell,
          Reference = request.Header.Reference,
          UserId = request.Header.User.Id
        };

        Datas.Instance.DataStorage.Headers.Add(item);
        request.Header.Id = item.Id;
      }

      HeadersResponse response = new HeadersResponse();
      response.Headers.Add(request.Header);
      return response;
    }
  }
}
