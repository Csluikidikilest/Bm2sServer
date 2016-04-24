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
using System;

namespace Bm2s.Services.Common.Trade.HeaderLine
{
  public class HeaderLinesService : Service
  {
    public HeaderLinesResponse Get(HeaderLines request)
    {
      HeaderLinesResponse response = new HeaderLinesResponse();
      List<Bm2s.Data.Common.BLL.Trade.Heli> items = new List<Data.Common.BLL.Trade.Heli>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.HeaderLines.Where(item =>
          (request.ArticleId == 0 || item.ArtiId == request.ArticleId) &&
          (request.ArticleFamilyId == 0 || item.ArfaId == request.ArticleFamilyId) &&
          (request.ArticleSubFamilyId == 0 || item.ArsfId == request.ArticleSubFamilyId) &&
          (request.BrandId == 0 || item.BranId == request.BrandId) &&
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Designation) || item.Designation.ToLower().Contains(request.Designation.ToLower())) &&
          (request.HeaderId == 0 || item.HeadId == request.HeaderId) &&
          (request.HeaderLineTypeId == 0 || item.HeltId == request.HeaderLineTypeId) &&
          (request.LineNumber == 0 || item.LineNumber == request.LineNumber) &&
          (request.UnitId == 0 || item.UnitId == request.UnitId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.HeaderLines.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Trade.HeaderLine()
                        {
                          Article = new ArticlesService().Get(new Articles() { Ids = new List<int>() { item.ArtiId } }).Articles.FirstOrDefault(),
                          ArticleFamily = new ArticleFamiliesService().Get(new ArticleFamilies() { Ids = new List<int>() { item.ArfaId } }).ArticleFamilies.FirstOrDefault(),
                          ArticleSubFamily = new ArticleSubFamiliesService().Get(new ArticleSubFamilies() { Ids = new List<int>() { item.ArsfId } }).ArticleSubFamilies.FirstOrDefault(),
                          Brand = new BrandsService().Get(new Brands() { Ids = new List<int>() { item.BranId } }).Brands.FirstOrDefault(),
                          BuyPrice = Convert.ToDecimal(item.BuyPrice),
                          Code = item.Code,
                          DeliveryObservation = item.DeliveryObservation,
                          Description = item.Description,
                          Designation = item.Designation,
                          Header = new HeadersService().Get(new Headers() { Ids = new List<int>() { item.HeadId } }).Headers.FirstOrDefault(),
                          HeaderLineType = new HeaderLineTypesService().Get(new HeaderLineTypes() { Ids = new List<int>() { item.HeltId } }).HeaderLineTypes.FirstOrDefault(),
                          Id = item.Id,
                          IsPrintable = item.IsPrintable,
                          LineNumber = item.LineNumber,
                          PreparationObservation = item.PreparationObservation,
                          Quantity = item.Quantity,
                          SellPrice = Convert.ToDecimal(item.SellPrice),
                          SupplierCompanyName = item.SupplierCompanyName,
                          Unit = new UnitsService().Get(new Units() { Ids = new List<int>() { item.UnitId } }).Units.FirstOrDefault(),
                          VatRate = Convert.ToDecimal(item.VatRate)
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.HeaderLines.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.HeaderLines.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.HeaderLines.Count + (collection.Count() % response.HeaderLines.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public HeaderLinesResponse Post(HeaderLines request)
    {
      if (request.HeaderLine.Id > 0)
      {
        Bm2s.Data.Common.BLL.Trade.Heli item = Datas.Instance.DataStorage.HeaderLines[request.HeaderLine.Id];
        item.ArfaId = request.HeaderLine.ArticleFamily.Id;
        item.ArtiId = request.HeaderLine.Article.Id;
        item.ArsfId = request.HeaderLine.ArticleSubFamily.Id;
        item.BranId = request.HeaderLine.Brand.Id;
        item.BuyPrice = Convert.ToDouble(request.HeaderLine.BuyPrice);
        item.Code = request.HeaderLine.Code;
        item.DeliveryObservation = request.HeaderLine.DeliveryObservation;
        item.Description = request.HeaderLine.Description;
        item.Designation = request.HeaderLine.Designation;
        item.HeadId = request.HeaderLine.Header.Id;
        item.HeltId = request.HeaderLine.HeaderLineType.Id;
        item.IsPrintable = request.HeaderLine.IsPrintable;
        item.LineNumber = request.HeaderLine.LineNumber;
        item.PreparationObservation = request.HeaderLine.PreparationObservation;
        item.Quantity = request.HeaderLine.Quantity;
        item.SellPrice = Convert.ToDouble(request.HeaderLine.SellPrice);
        item.SupplierCompanyName = request.HeaderLine.SupplierCompanyName;
        item.UnitId = request.HeaderLine.Unit.Id;
        item.VatRate = Convert.ToDouble(request.HeaderLine.VatRate);
        Datas.Instance.DataStorage.HeaderLines[request.HeaderLine.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Trade.Heli item = new Data.Common.BLL.Trade.Heli()
        {
          ArfaId = request.HeaderLine.ArticleFamily.Id,
          ArtiId = request.HeaderLine.Article.Id,
          ArsfId = request.HeaderLine.ArticleSubFamily.Id,
          BranId = request.HeaderLine.Brand.Id,
          BuyPrice = Convert.ToDouble(request.HeaderLine.BuyPrice),
          Code = request.HeaderLine.Code,
          DeliveryObservation = request.HeaderLine.DeliveryObservation,
          Description = request.HeaderLine.Description,
          Designation = request.HeaderLine.Designation,
          HeadId = request.HeaderLine.Header.Id,
          HeltId = request.HeaderLine.HeaderLineType.Id,
          IsPrintable = request.HeaderLine.IsPrintable,
          LineNumber = request.HeaderLine.LineNumber,
          PreparationObservation = request.HeaderLine.PreparationObservation,
          Quantity = request.HeaderLine.Quantity,
          SellPrice = Convert.ToDouble(request.HeaderLine.SellPrice),
          SupplierCompanyName = request.HeaderLine.SupplierCompanyName,
          UnitId = request.HeaderLine.Unit.Id,
          VatRate = Convert.ToDouble(request.HeaderLine.VatRate)
        };

        Datas.Instance.DataStorage.HeaderLines.Add(item);
        request.HeaderLine.Id = item.Id;
      }

      HeaderLinesResponse response = new HeaderLinesResponse();
      response.HeaderLines.Add(request.HeaderLine);
      return response;
    }

    public HeaderLinesResponse Delete(HeaderLines request)
    {
      Bm2s.Data.Common.BLL.Trade.Heli item = Datas.Instance.DataStorage.HeaderLines[request.HeaderLine.Id];
      Datas.Instance.DataStorage.HeaderLines.Remove(item);

      HeaderLinesResponse response = new HeaderLinesResponse();
      response.HeaderLines.Add(request.HeaderLine);
      return response;
    }
  }
}
