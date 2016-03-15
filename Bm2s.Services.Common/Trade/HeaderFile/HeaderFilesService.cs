using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Trade.Header;
using Bm2s.Response.Common.Trade.HeaderFile;
using Bm2s.Response.Common.User.User;
using Bm2s.Services.Common.Trade.Header;
using Bm2s.Services.Common.User.User;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Trade.HeaderFile
{
  public class HeaderFilesService : Service
  {
    public HeaderFilesResponse Get(HeaderFiles request)
    {
      HeaderFilesResponse response = new HeaderFilesResponse();
      List<Bm2s.Data.Common.BLL.Trade.HeaderFile> items = new List<Data.Common.BLL.Trade.HeaderFile>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.HeaderFiles.Where(item =>
          (request.HeaderId == 0 || item.HeaderId == request.HeaderId) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower())) &&
          (request.UserId == 0 || item.UserId == request.UserId) &&
          (!request.AddingDate.HasValue || request.AddingDate >= item.AddingDate)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.HeaderFiles.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Trade.HeaderFile()
                        {
                          AddingDate = item.AddingDate,
                          File = item.File,
                          Header = new HeadersService().Get(new Headers() { Ids = new List<int>() { item.HeaderId } }).Headers.FirstOrDefault(),
                          Id = item.Id,
                          Name = item.Name,
                          User = new UsersService().Get(new Users() { Ids = new List<int>() { item.UserId } }).Users.FirstOrDefault()
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.HeaderFiles.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.HeaderFiles.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.HeaderFiles.Count + (collection.Count() % response.HeaderFiles.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public HeaderFilesResponse Post(HeaderFiles request)
    {
      if (request.HeaderFile.Id > 0)
      {
        Bm2s.Data.Common.BLL.Trade.HeaderFile item = Datas.Instance.DataStorage.HeaderFiles[request.HeaderFile.Id];
        item.AddingDate = request.HeaderFile.AddingDate;
        item.File = request.HeaderFile.File;
        item.HeaderId = request.HeaderFile.Header.Id;
        item.Name = request.HeaderFile.Name;
        item.UserId = request.HeaderFile.User.Id;
        Datas.Instance.DataStorage.HeaderFiles[request.HeaderFile.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Trade.HeaderFile item = new Data.Common.BLL.Trade.HeaderFile()
        {
          AddingDate = request.HeaderFile.AddingDate,
          File = request.HeaderFile.File,
          HeaderId = request.HeaderFile.Header.Id,
          Name = request.HeaderFile.Name,
          UserId = request.HeaderFile.User.Id
        };

        Datas.Instance.DataStorage.HeaderFiles.Add(item);
        request.HeaderFile.Id = item.Id;
      }

      HeaderFilesResponse response = new HeaderFilesResponse();
      response.HeaderFiles.Add(request.HeaderFile);
      return response;
    }

    public HeaderFilesResponse Delete(HeaderFiles request)
    {
      Bm2s.Data.Common.BLL.Trade.HeaderFile item = Datas.Instance.DataStorage.HeaderFiles.FirstOrDefault(nomenclature => nomenclature.Id == request.HeaderFile.Id);
      if (item != null)
      {
        Datas.Instance.DataStorage.HeaderFiles.Remove(item);
      }

      HeaderFilesResponse response = new HeaderFilesResponse();
      response.HeaderFiles.Add(request.HeaderFile);
      return response;
    }
  }
}
