using System.ComponentModel.DataAnnotations.Schema;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Article
{
  public class ArticleFamilyPricePartner
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [Default(0)]
    public double? Price { get; set; }

    public bool AddPrice { get; set; }

    [Default(1)]
    public double? Multiplier { get; set; }

    [References(typeof(ArticleFamily))]
    public int ArticleFamilyId { get; set; }

    [References(typeof(Partner.Partner))]
    public int PartnerId { get; set; }
  }
}
