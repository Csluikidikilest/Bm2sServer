using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class Inli : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public int Quantity { get; set; }

    [References(typeof(Inhe))]
    public int InheId { get; set; }

    [References(typeof(Article.Arti))]
    public int ArtiId { get; set; }
  }
}
