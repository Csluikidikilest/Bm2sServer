
namespace Bm2s.Poco.Common.Parameter
{
  public class UnitConversion
  {
    public int Id { get; set; }

    public int Quantity { get; set; }

    public int Multiplier { get; set; }

    public Unit Child { get; set; }

    public Unit Parent { get; set; }
  }
}
