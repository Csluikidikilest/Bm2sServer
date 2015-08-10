using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Partner.PartnerFil
{
  class PartnerFilesService : Service
  {
    public object Get(PartnerFiles request)
    {
      PartnerFilesResponse response = new PartnerFilesResponse();

      if (!request.Ids.Any())
      {
        response.PartnerFiles.AddRange(Datas.Instance.DataStorage.PartnerFiles.Where(item =>
          (request.PartnerId == 0 || item.PartnerId == request.PartnerId) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower())) &&
          (request.UserId == 0 || item.UserId == request.UserId) &&
          (!request.AddingDate.HasValue || request.AddingDate >= item.AddingDate)
          ));
      }
      else
      {
        response.PartnerFiles.AddRange(Datas.Instance.DataStorage.PartnerFiles.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(PartnerFiles request)
    {
      if (request.PartnerFile.Id > 0)
      {
        Datas.Instance.DataStorage.PartnerFiles[request.PartnerFile.Id] = request.PartnerFile;
      }
      else
      {
        Datas.Instance.DataStorage.PartnerFiles.Add(request.PartnerFile);
      }
      return request.PartnerFile;
    }
  }
}
