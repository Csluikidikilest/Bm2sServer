using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Trade.HeaderFile
{
  public class HeaderFilesService : Service
  {
    public object Get(HeaderFiles request)
    {
      HeaderFilesResponse response = new HeaderFilesResponse();

      if (!request.Ids.Any())
      {
        response.HeaderFiles.AddRange(Datas.Instance.DataStorage.HeaderFiles);
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
