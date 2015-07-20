using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Article.PriceDetermination
{
  public class PriceDeterminationResponse
  {
    private double? _totalPrice;

    public PriceDeterminationResponse()
    {
      this.articleFamilyPricePartnerFamilies = new List<BLL.Article.ArticleFamilyPricePartnerFamily>();
      this.articleSubFamilyPricePartnerFamilies = new List<BLL.Article.ArticleSubFamilyPricePartnerFamily>();
      this.articlePriceParnerFamilies = new List<BLL.Article.ArticlePriceParnerFamily>();
    }

    public BLL.Article.Price Price { get; set; }

    public List<BLL.Article.ArticleFamilyPricePartnerFamily> articleFamilyPricePartnerFamilies { get; set; }

    public BLL.Article.ArticleFamilyPricePartner articleFamilyPricePartners { get; set; }

    public List<BLL.Article.ArticleSubFamilyPricePartnerFamily> articleSubFamilyPricePartnerFamilies { get; set; }

    public BLL.Article.ArticleSubFamilyPricePartner articleSubFamilyPricePartners { get; set; }

    public List<BLL.Article.ArticlePriceParnerFamily> articlePriceParnerFamilies { get; set; }

    public BLL.Article.ArticlePriceParner articlePriceParners { get; set; }

    public double TotalPrice
    {
      get
      {
        if (!this._totalPrice.HasValue)
        {
          this._totalPrice = this.Price.BasePrice;

          // The price of this article for the partner
          if (this.articlePriceParners.Multiplier.HasValue)
          {
            this._totalPrice *= this.articlePriceParners.Multiplier;
          }
          else if (this.articlePriceParners.AddPrice)
          {
            this._totalPrice += this.articlePriceParners.Price;
          }
          else
          {
            this._totalPrice = this.articlePriceParners.Price;
            return this._totalPrice.Value;
          }

          // The price of the sub family of this article for the parner
          if (this.articleSubFamilyPricePartners.Multiplier.HasValue)
          {
            this._totalPrice *= this.articleSubFamilyPricePartners.Multiplier;
          }
          else if (this.articleSubFamilyPricePartners.AddPrice)
          {
            this._totalPrice += this.articleSubFamilyPricePartners.Price;
          }
          else
          {
            this._totalPrice = this.articleSubFamilyPricePartners.Price;
            return this._totalPrice.Value;
          }

          // The price of the family of this article for the parner
          if (this.articleFamilyPricePartners.Multiplier.HasValue)
          {
            this._totalPrice *= this.articleFamilyPricePartners.Multiplier;
          }
          else if (this.articleFamilyPricePartners.AddPrice)
          {
            this._totalPrice += this.articleFamilyPricePartners.Price;
          }
          else
          {
            this._totalPrice = this.articleFamilyPricePartners.Price;
            return this._totalPrice.Value;
          }

          // Each price modifier of this article for the partner families
          foreach (BLL.Article.ArticlePriceParnerFamily item in articlePriceParnerFamilies)
          {
            if (item.Multiplier.HasValue)
            {
              this._totalPrice *= item.Multiplier.Value;
            }
            else
            {
              this._totalPrice += item.Price.Value;
            }
          }

          // Each price modifier of the sub family of this article for the partner families
          foreach (BLL.Article.ArticleSubFamilyPricePartnerFamily item in articleSubFamilyPricePartnerFamilies)
          {
            if (item.Multiplier.HasValue)
            {
              this._totalPrice *= item.Multiplier.Value;
            }
            else
            {
              this._totalPrice += item.Price.Value;
            }
          }

          // Each price modifier of the family of this article for the partner families
          foreach (BLL.Article.ArticleFamilyPricePartnerFamily item in articleFamilyPricePartnerFamilies)
          {
            if (item.Multiplier.HasValue)
            {
              this._totalPrice *= item.Multiplier.Value;
            }
            else
            {
              this._totalPrice += item.Price.Value;
            }
          }
        }

        return this._totalPrice.Value;
      }
    }
  }
}
