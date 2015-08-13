using System;

namespace Bm2s.Poco.Common.Parameter
{
  public class CountryCurrency
  {
    public int Id { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public Country Country { get; set; }

    public Unit Unit { get; set; }
  }
}
