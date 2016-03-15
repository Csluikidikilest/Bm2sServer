using System;
using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Partner.AddressType;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Partner.AddressType
{
  class AddressTypesService : Service
  {
    public AddressTypesResponse Get(AddressTypes request)
    {
      AddressTypesResponse response = new AddressTypesResponse();
      List<Bm2s.Data.Common.BLL.Partner.AddressType> items = new List<Data.Common.BLL.Partner.AddressType>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.AddressTypes.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower()))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.AddressTypes.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Partner.AddressType()
                        {
                          Code = item.Code,
                          EndingDate = item.EndingDate,
                          Id = item.Id,
                          Name = item.Name,
                          StartingDate = item.StartingDate
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.AddressTypes.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.AddressTypes.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.AddressTypes.Count + (collection.Count() % response.AddressTypes.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public AddressTypesResponse Post(AddressTypes request)
    {
      if (request.AddressType.Id > 0)
      {
        Bm2s.Data.Common.BLL.Partner.AddressType item = Datas.Instance.DataStorage.AddressTypes[request.AddressType.Id];
        item.Code = request.AddressType.Code;
        item.EndingDate = request.AddressType.EndingDate;
        item.Name = request.AddressType.Name;
        item.StartingDate = request.AddressType.StartingDate;
        Datas.Instance.DataStorage.AddressTypes[request.AddressType.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Partner.AddressType item = new Data.Common.BLL.Partner.AddressType()
        {
          Code = request.AddressType.Code,
          EndingDate = request.AddressType.EndingDate,
          Name = request.AddressType.Name,
          StartingDate = request.AddressType.StartingDate
        };

        Datas.Instance.DataStorage.AddressTypes.Add(item);
        request.AddressType.Id = item.Id;
      }

      AddressTypesResponse response = new AddressTypesResponse();
      response.AddressTypes.Add(request.AddressType);
      return response;
    }

    public AddressTypesResponse Delete(AddressTypes request)
    {
      Bm2s.Data.Common.BLL.Partner.AddressType item = Datas.Instance.DataStorage.AddressTypes[request.AddressType.Id];
      item.EndingDate = DateTime.Now;

      AddressTypesResponse response = new AddressTypesResponse();
      response.AddressTypes.Add(request.AddressType);
      return response;
    }
  }
}
