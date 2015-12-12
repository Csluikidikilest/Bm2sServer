using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Partner.Address;
using Bm2s.Response.Common.Partner.AddressLine;
using Bm2s.Services.Common.Partner.Address;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Partner.AddressLine
{
  class AddressLinesService : Service
  {
    public AddressLinesResponse Get(AddressLines request)
    {
      AddressLinesResponse response = new AddressLinesResponse();
      List<Bm2s.Data.Common.BLL.Partner.AddressLine> items = new List<Data.Common.BLL.Partner.AddressLine>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.AddressLines.Where(item =>
          (request.AddressId == 0 || item.AddressId == request.AddressId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.AddressLines.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Partner.AddressLine()
                        {
                          Address = new AddressesService().Get(new Addresses() { Ids = new List<int>() { item.AddressId } }).Addresses.FirstOrDefault(),
                          Id = item.Id,
                          Line = item.Line,
                          Order = item.Order
                        }).AsQueryable().OrderBy(request.Order, request.AscendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.AddressLines.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.AddressLines.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.AddressLines.Count + (collection.Count() % response.AddressLines.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public AddressLinesResponse Post(AddressLines request)
    {
      if (request.AddressLine.Id > 0)
      {
        Bm2s.Data.Common.BLL.Partner.AddressLine item = Datas.Instance.DataStorage.AddressLines[request.AddressLine.Id];
        item.AddressId = request.AddressLine.Address.Id;
        item.Line = request.AddressLine.Line;
        item.Order = request.AddressLine.Order;
        Datas.Instance.DataStorage.AddressLines[request.AddressLine.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Partner.AddressLine item = new Data.Common.BLL.Partner.AddressLine()
        {
          AddressId = request.AddressLine.Address.Id,
          Line = request.AddressLine.Line,
          Order = request.AddressLine.Order
        };

        Datas.Instance.DataStorage.AddressLines.Add(item);
        request.AddressLine.Id = item.Id;
      }

      AddressLinesResponse response = new AddressLinesResponse();
      response.AddressLines.Add(request.AddressLine);
      return response;
    }
  }
}
