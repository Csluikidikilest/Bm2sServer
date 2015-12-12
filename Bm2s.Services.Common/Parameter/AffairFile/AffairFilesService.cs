using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Parameter.Affair;
using Bm2s.Response.Common.Parameter.AffairFile;
using Bm2s.Response.Common.User.User;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.AffairFile
{
  public class AffairFilesService : Service
  {
    public AffairFilesResponse Get(AffairFiles request)
    {
      AffairFilesResponse response = new AffairFilesResponse();
      List<Bm2s.Data.Common.BLL.Parameter.AffairFile> items = new List<Data.Common.BLL.Parameter.AffairFile>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.AffairFiles.Where(item =>
          (request.AffairId == 0 || item.AffairId == request.AffairId) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower())) &&
          (request.UserId == 0 || item.UserId == request.UserId) &&
          (!request.AddingDate.HasValue || request.AddingDate >= item.AddingDate)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.AffairFiles.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Parameter.AffairFile()
                        {
                          AddingDate = item.AddingDate,
                          Affair = new Affair.AffairsService().Get(new Affairs() { Ids = new List<int>() { item.AffairId } }).Affairs.FirstOrDefault(),
                          File = item.File,
                          Id = item.Id,
                          Name = item.Name,
                          User = new User.User.UsersService().Get(new Users() { Ids = new List<int>() { item.UserId } }).Users.FirstOrDefault()
                        }).AsQueryable().OrderBy(request.Order, request.AscendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.AffairFiles.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.AffairFiles.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.AffairFiles.Count + (collection.Count() % response.AffairFiles.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public AffairFilesResponse Post(AffairFiles request)
    {
      if (request.AffairFile.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.AffairFile item = Datas.Instance.DataStorage.AffairFiles[request.AffairFile.Id];
        item.AddingDate = request.AffairFile.AddingDate;
        item.AffairId = request.AffairFile.Affair.Id;
        item.File = request.AffairFile.File;
        item.Name = request.AffairFile.Name;
        item.UserId = request.AffairFile.User.Id;
        Datas.Instance.DataStorage.AffairFiles[request.AffairFile.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.AffairFile item = new Data.Common.BLL.Parameter.AffairFile()
        {
          AddingDate = request.AffairFile.AddingDate,
          AffairId = request.AffairFile.Affair.Id,
          File = request.AffairFile.File,
          Name = request.AffairFile.Name,
          UserId = request.AffairFile.User.Id
        };

        Datas.Instance.DataStorage.AffairFiles.Add(item);
        request.AffairFile.Id = item.Id;
      }

      AffairFilesResponse response = new AffairFilesResponse();
      response.AffairFiles.Add(request.AffairFile);
      return response;
    }
  }
}
