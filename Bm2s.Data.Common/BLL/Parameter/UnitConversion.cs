using Bm2s.Data.Common.Utils;
using ServiceStack.DataAnnotations;
using System.Linq;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class UnitConversion : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Default(0)]
    public int Quantity { get; set; }

    [Default(1)]
    public int Multiplier { get; set; }

    [References(typeof(Unit))]
    public int ChildId { get; set; }

    [Ignore]
    public Unit Child { get; set; }

    [References(typeof(Unit))]
    public int ParentId { get; set; }

    [Ignore]
    public Unit Parent { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.Child = Datas.Instance.DataStorage.Units.FirstOrDefault<Unit>(item => item.Id == this.ChildId);
      this.Parent = Datas.Instance.DataStorage.Units.FirstOrDefault<Unit>(item => item.Id == this.ParentId);
    }
  }
}
