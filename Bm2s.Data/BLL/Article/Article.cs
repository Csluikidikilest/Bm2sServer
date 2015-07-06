using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Data.BLL.Parameter;
using Bm2s.Data.BLL.Sell;

namespace Bm2s.Data.BLL.Article
{
  public class Article
  {
    public int Id { get; private set; }
    public string Code { get; set; }
    public string Designation { get; set; }
    public string Description { get; set; }
    public decimal SellPrice { get; set; }
    public string Observation { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }
    public ArticleFamily Family { get; set; }
    public ArticleSubFamily SubFamily { get; set; }
    public Brand Brand { get; set; }
    public Parameter.Unit Unit { get; set; }
    public List<ArticlePriceParner> ArticlePriceParners { get; set; }
    public List<ArticlePriceParnerFamily> ArticlePriceParnerFamilys { get; set; }
    public List<Price> Prices { get; set; }
    public List<Nomenclature> NomenclatureParents { get; set; }
    public List<Nomenclature> NomenclatureChildren { get; set; }
    public List<ArticlePartnerFamilyVat> ArticlePartnerFamilyVats { get; set; }
    public List<ArticlePartnerVat> ArticlePartnerVats { get; set; }
    public List<InventoryLine> InventoryLines { get; set; }
    public List<HeaderLine> HeaderLines { get; set; }
  }
}
