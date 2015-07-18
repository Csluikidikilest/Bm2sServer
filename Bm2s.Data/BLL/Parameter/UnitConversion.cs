using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class UnitConversion : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; protected set; }

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
  }
}
