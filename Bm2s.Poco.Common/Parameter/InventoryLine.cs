
namespace Bm2s.Poco.Common.Parameter
{
  public class InventoryLine
  {
    public int Id { get; set; }

    public int Quantity { get; set; }

    public InventoryHeader InventoryHeader { get; set; }

    public Article.Article Article { get; set; }
  }
}
