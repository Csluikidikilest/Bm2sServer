using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Trade.HeaderLine
{
  public class HeaderLinesService : Service
  {
    public object Get(HeaderLines request)
    {
      HeaderLinesResponse response = new HeaderLinesResponse();

      if (!request.Ids.Any())
      {
        response.HeaderLines.AddRange(Datas.Instance.DataStorage.HeaderLines.Where(item =>
          (request.ArticleId == 0 || item.ArticleId == request.ArticleId) &&
          (request.ArticleFamilyId == 0 || item.ArticleFamilyId == request.ArticleFamilyId) &&
          (request.ArticleSubFamilyId == 0 || item.ArticleSubFamilyId == request.ArticleSubFamilyId) &&
          (request.BrandId == 0 || item.BrandId == request.BrandId) &&
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Designation) || item.Designation.ToLower().Contains(request.Designation.ToLower())) &&
          (request.HeaderId== 0 || item.HeaderId == request.HeaderId) &&
          (request.HeaderLineTypeId== 0 || item.HeaderLineTypeId== request.HeaderLineTypeId) &&
          (request.LineNumber== 0 || item.LineNumber== request.LineNumber) &&
          (request.UnitId == 0 || item.UnitId == request.UnitId)
          ));
      }
      else
      {
        response.HeaderLines.AddRange(Datas.Instance.DataStorage.HeaderLines.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(HeaderLines request)
    {
      if (request.HeaderLine.Id > 0)
      {
        Datas.Instance.DataStorage.HeaderLines[request.HeaderLine.Id] = request.HeaderLine;
      }
      else
      {
        Datas.Instance.DataStorage.HeaderLines.Add(request.HeaderLine);
      }
      return request.HeaderLine;
    }
  }
}
