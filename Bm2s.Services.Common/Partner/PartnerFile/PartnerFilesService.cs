using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Services.Common.Partner.Partner;
using Bm2s.Services.Common.User.User;
using ServiceStack.ServiceInterface;
using Bm2s.Services.Common.Partner.PartnerFile;
using Bm2s.Response.Common.Partner.PartnerFil;
using Bm2s.Response.Common.Partner.Partner;
using Bm2s.Response.Common.User.User;

namespace Bm2s.Services.Common.Partner.PartnerFile
{
  class PartnerFilesService : Service
  {
    public PartnerFilesResponse Get(PartnerFiles request)
    {
      PartnerFilesResponse response = new PartnerFilesResponse();
      List<Bm2s.Data.Common.BLL.Partner.Pafi> items = new List<Data.Common.BLL.Partner.Pafi>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.PartnerFiles.Where(item =>
          (request.PartnerId == 0 || item.PartId == request.PartnerId) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower())) &&
          (request.UserId == 0 || item.UserId == request.UserId) &&
          (!request.AddingDate.HasValue || request.AddingDate >= item.AddingDate)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.PartnerFiles.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Partner.PartnerFile()
                        {
                          AddingDate = item.AddingDate,
                          Content = item.Content,
                          Id = item.Id,
                          Name = item.Name,
                          Partner = new PartnersService().Get(new Partners() { Ids = new List<int>() { item.PartId } }).Partners.FirstOrDefault(),
                          User = new UsersService().Get(new Users() { Ids = new List<int>() { item.UserId } }).Users.FirstOrDefault()
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.PartnerFiles.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.PartnerFiles.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.PartnerFiles.Count + (collection.Count() % response.PartnerFiles.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public PartnerFilesResponse Post(PartnerFiles request)
    {
      if (request.PartnerFile.Id > 0)
      {
        Bm2s.Data.Common.BLL.Partner.Pafi item = Datas.Instance.DataStorage.PartnerFiles[request.PartnerFile.Id];
        item.AddingDate = request.PartnerFile.AddingDate;
        item.Content = request.PartnerFile.Content;
        item.Name = request.PartnerFile.Name;
        item.PartId = request.PartnerFile.Partner.Id;
        item.UserId = request.PartnerFile.User.Id;
        Datas.Instance.DataStorage.PartnerFiles[request.PartnerFile.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Partner.Pafi item = new Data.Common.BLL.Partner.Pafi()
        {
          AddingDate = request.PartnerFile.AddingDate,
          Content = request.PartnerFile.Content,
          Name = request.PartnerFile.Name,
          PartId = request.PartnerFile.Partner.Id,
          UserId = request.PartnerFile.User.Id
        };

        Datas.Instance.DataStorage.PartnerFiles.Add(item);
        request.PartnerFile.Id = item.Id;
      }

      PartnerFilesResponse response = new PartnerFilesResponse();
      response.PartnerFiles.Add(request.PartnerFile);
      return response;
    }

    public PartnerFilesResponse Delete(PartnerFiles request)
    {
      Bm2s.Data.Common.BLL.Partner.Pafi item = Datas.Instance.DataStorage.PartnerFiles[request.PartnerFile.Id];
      Datas.Instance.DataStorage.PartnerFiles.Remove(item);

      PartnerFilesResponse response = new PartnerFilesResponse();
      response.PartnerFiles.Add(request.PartnerFile);
      return response;
    }
  }
}
