using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Article.Article;
using Bm2s.Response.Common.Article.ArticleFamily;
using Bm2s.Response.Common.Article.ArticleSubFamily;
using Bm2s.Response.Common.Article.Brand;
using Bm2s.Response.Common.Parameter.Unit;
using Bm2s.Response.Common.Trade.Header;
using Bm2s.Response.Common.Trade.HeaderLine;
using Bm2s.Response.Common.Trade.HeaderLineType;
using Bm2s.Services.Common.Article.Article;
using Bm2s.Services.Common.Article.ArticleFamily;
using Bm2s.Services.Common.Article.ArticleSubFamily;
using Bm2s.Services.Common.Article.Brand;
using Bm2s.Services.Common.Parameter.Unit;
using Bm2s.Services.Common.Trade.Header;
using Bm2s.Services.Common.Trade.HeaderLineType;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Trade.HeaderLine
{
  public class HeaderLinesService : Service
  {
    public HeaderLinesResponse Get(HeaderLines request)
    {
      HeaderLinesResponse response = new HeaderLinesResponse();
      List<Bm2s.Data.Common.BLL.Trade.HeaderLine> items = new List<Data.Common.BLL.Trade.HeaderLine>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.HeaderLines.Where(item =>
          (request.ArticleId == 0 || item.ArticleId == request.ArticleId) &&
          (request.ArticleFamilyId == 0 || item.ArticleFamilyId == request.ArticleFamilyId) &&
          (request.ArticleSubFamilyId == 0 || item.ArticleSubFamilyId == request.ArticleSubFamilyId) &&
          (request.BrandId == 0 || item.BrandId == request.BrandId) &&
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Designation) || item.Designation.ToLower().Contains(request.Designation.ToLower())) &&
          (request.HeaderId == 0 || item.HeaderId == request.HeaderId) &&
          (request.HeaderLineTypeId == 0 || item.HeaderLineTypeId == request.HeaderLineTypeId) &&
          (request.LineNumber == 0 || item.LineNumber == request.LineNumber) &&
          (request.UnitId == 0 || item.UnitId == request.UnitId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.HeaderLines.Where(item => request.Ids.Contains(item.Id)));
      }

      response.HeaderLines.AddRange(from item in items
                                    select new Bm2s.Poco.Common.Trade.HeaderLine()
                                    {
                                      Article = new ArticlesService().Get(new Articles() { Ids = new List<int>() { item.ArticleId } }).Articles.FirstOrDefault(),
                                      ArticleFamily = new ArticleFamiliesService().Get(new ArticleFamilies() { Ids = new List<int>() { item.ArticleFamilyId } }).ArticleFamilies.FirstOrDefault(),
                                      ArticleSubFamily = new ArticleSubFamiliesService().Get(new ArticleSubFamilies() { Ids = new List<int>() { item.ArticleSubFamilyId } }).ArticleSubFamilies.FirstOrDefault(),
                                      Brand = new BrandsService().Get(new Brands() { Ids = new List<int>() { item.BrandId } }).Brands.FirstOrDefault(),
                                      BuyPrice = item.BuyPrice,
                                      Code = item.Code,
                                      DeliveryObservation = item.DeliveryObservation,
                                      Description = item.Description,
                                      Designation = item.Designation,
                                      Header = new HeadersService().Get(new Headers() { Ids = new List<int>() { item.HeaderId } }).Headers.FirstOrDefault(),
                                      HeaderLineType = new HeaderLineTypesService().Get(new HeaderLineTypes() { Ids = new List<int>() { item.HeaderLineTypeId } }).HeaderLineTypes.FirstOrDefault(),
                                      Id = item.Id,
                                      IsPrintable = item.IsPrintable,
                                      LineNumber = item.LineNumber,
                                      PreparationObservation = item.PreparationObservation,
                                      Quantity = item.Quantity,
                                      SellPrice = item.SellPrice,
                                      SupplierCompanyName = item.SupplierCompanyName,
                                      Unit = new UnitsService().Get(new Units() { Ids = new List<int>() { item.UnitId } }).Units.FirstOrDefault(),
                                      VatRate = item.VatRate
                                    });

      return response;
    }

    public HeaderLinesResponse Post(HeaderLines request)
    {
      if (request.HeaderLine.Id > 0)
      {
        Bm2s.Data.Common.BLL.Trade.HeaderLine item = Datas.Instance.DataStorage.HeaderLines[request.HeaderLine.Id];
        item.ArticleFamilyId = request.HeaderLine.ArticleFamily.Id;
        item.ArticleId = request.HeaderLine.Article.Id;
        item.ArticleSubFamilyId = request.HeaderLine.ArticleSubFamily.Id;
        item.BrandId = request.HeaderLine.Brand.Id;
        item.BuyPrice = request.HeaderLine.BuyPrice;
        item.Code = request.HeaderLine.Code;
        item.DeliveryObservation = request.HeaderLine.DeliveryObservation;
        item.Description = request.HeaderLine.Description;
        item.Designation = request.HeaderLine.Designation;
        item.HeaderId = request.HeaderLine.Header.Id;
        item.HeaderLineTypeId = request.HeaderLine.HeaderLineType.Id;
        item.IsPrintable = request.HeaderLine.IsPrintable;
        item.LineNumber = request.HeaderLine.LineNumber;
        item.PreparationObservation = request.HeaderLine.PreparationObservation;
        item.Quantity = request.HeaderLine.Quantity;
        item.SellPrice = request.HeaderLine.SellPrice;
        item.SupplierCompanyName = request.HeaderLine.SupplierCompanyName;
        item.UnitId = request.HeaderLine.Unit.Id;
        item.VatRate = request.HeaderLine.VatRate;
        Datas.Instance.DataStorage.HeaderLines[request.HeaderLine.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Trade.HeaderLine item = new Data.Common.BLL.Trade.HeaderLine()
        {
          ArticleFamilyId = request.HeaderLine.ArticleFamily.Id,
          ArticleId = request.HeaderLine.Article.Id,
          ArticleSubFamilyId = request.HeaderLine.ArticleSubFamily.Id,
          BrandId = request.HeaderLine.Brand.Id,
          BuyPrice = request.HeaderLine.BuyPrice,
          Code = request.HeaderLine.Code,
          DeliveryObservation = request.HeaderLine.DeliveryObservation,
          Description = request.HeaderLine.Description,
          Designation = request.HeaderLine.Designation,
          HeaderId = request.HeaderLine.Header.Id,
          HeaderLineTypeId = request.HeaderLine.HeaderLineType.Id,
          IsPrintable = request.HeaderLine.IsPrintable,
          LineNumber = request.HeaderLine.LineNumber,
          PreparationObservation = request.HeaderLine.PreparationObservation,
          Quantity = request.HeaderLine.Quantity,
          SellPrice = request.HeaderLine.SellPrice,
          SupplierCompanyName = request.HeaderLine.SupplierCompanyName,
          UnitId = request.HeaderLine.Unit.Id,
          VatRate = request.HeaderLine.VatRate
        };

        Datas.Instance.DataStorage.HeaderLines.Add(item);
        request.HeaderLine.Id = item.Id;
      }

      HeaderLinesResponse response = new HeaderLinesResponse();
      response.HeaderLines.Add(request.HeaderLine);
      return response;
    }
  }
}
