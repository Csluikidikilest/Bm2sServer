using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Parameter.AffairFile
{
public  class AffairFilesService : Service
  {
  public object Get(AffairFiles request)
    {
      AffairFilesResponse response = new AffairFilesResponse();

      if (!request.Ids.Any())
      {
        response.AffairFiles.AddRange(Datas.Instance.DataStorage.AffairFiles.Where(item =>
          (request.AffairId == 0 || item.AffairId == request.AffairId) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower())) &&
          (request.UserId == 0 || item.UserId == request.UserId) &&
          (!request.AddingDate.HasValue || request.AddingDate >= item.AddingDate)
          ));
      }
      else
      {
        response.AffairFiles.AddRange(Datas.Instance.DataStorage.AffairFiles.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

  public object Post(AffairFiles request)
    {
      if (request.AffairFile.Id > 0)
      {
        Datas.Instance.DataStorage.AffairFiles[request.AffairFile.Id] = request.AffairFile;
      }
      else
      {
        Datas.Instance.DataStorage.AffairFiles.Add(request.AffairFile);
      }
      return request.AffairFile;
    }
  }
}
