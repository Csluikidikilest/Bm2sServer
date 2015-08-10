using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Trade.HeaderFile
{
  public class HeaderFilesService : Service
  {
    public object Get(HeaderFiles request)
    {
      HeaderFilesResponse response = new HeaderFilesResponse();

      if (!request.Ids.Any())
      {
        response.HeaderFiles.AddRange(Datas.Instance.DataStorage.HeaderFiles.Where(item =>
          (request.HeaderId == 0 || item.HeaderId == request.HeaderId) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower())) &&
          (request.UserId == 0 || item.UserId == request.UserId) &&
          (!request.AddingDate.HasValue || request.AddingDate >= item.AddingDate)
          ));
      }
      else
      {
        response.HeaderFiles.AddRange(Datas.Instance.DataStorage.HeaderFiles.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(HeaderFiles request)
    {
      if (request.HeaderFile.Id > 0)
      {
        Datas.Instance.DataStorage.HeaderFiles[request.HeaderFile.Id] = request.HeaderFile;
      }
      else
      {
        Datas.Instance.DataStorage.HeaderFiles.Add(request.HeaderFile);
      }
      return request.HeaderFile;
    }
  }
}
