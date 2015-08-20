using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Services.Common.Partner.Partner;
using Bm2s.Services.Common.User.User;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Partner.PartnerFil
{
  class PartnerFilesService : Service
  {
    public PartnerFilesResponse Get(PartnerFiles request)
    {
      PartnerFilesResponse response = new PartnerFilesResponse();
      List<Bm2s.Data.Common.BLL.Partner.PartnerFile> items = new List<Data.Common.BLL.Partner.PartnerFile>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.PartnerFiles.Where(item =>
          (request.PartnerId == 0 || item.PartnerId == request.PartnerId) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower())) &&
          (request.UserId == 0 || item.UserId == request.UserId) &&
          (!request.AddingDate.HasValue || request.AddingDate >= item.AddingDate)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.PartnerFiles.Where(item => request.Ids.Contains(item.Id)));
      }

      response.PartnerFiles.AddRange(from item in items
                                     select new Bm2s.Poco.Common.Partner.PartnerFile()
                                     {
                                       AddingDate = item.AddingDate,
                                       File = item.File,
                                       Id = item.Id,
                                       Name = item.Name,
                                       Partner = new PartnersService().Get(new Partners() { Ids = new List<int>() { item.PartnerId } }).Partners.FirstOrDefault(),
                                       User = new UsersService().Get(new Users() { Ids = new List<int>() { item.UserId } }).Users.FirstOrDefault()
                                     });

      return response;
    }

    public Bm2s.Poco.Common.Partner.PartnerFile Post(PartnerFiles request)
    {
      if (request.PartnerFile.Id > 0)
      {
        Bm2s.Data.Common.BLL.Partner.PartnerFile item = Datas.Instance.DataStorage.PartnerFiles[request.PartnerFile.Id];
        item.AddingDate = request.PartnerFile.AddingDate;
        item.File = request.PartnerFile.File;
        item.Name = request.PartnerFile.Name;
        item.PartnerId = request.PartnerFile.Partner.Id;
        item.UserId = request.PartnerFile.User.Id;
        Datas.Instance.DataStorage.PartnerFiles[request.PartnerFile.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Partner.PartnerFile item = new Data.Common.BLL.Partner.PartnerFile()
        {
          AddingDate = request.PartnerFile.AddingDate,
          File = request.PartnerFile.File,
          Name = request.PartnerFile.Name,
          PartnerId = request.PartnerFile.Partner.Id,
          UserId = request.PartnerFile.User.Id
        };

        Datas.Instance.DataStorage.PartnerFiles.Add(item);
        request.PartnerFile.Id = item.Id;
      }

      return request.PartnerFile;
    }
  }
}
