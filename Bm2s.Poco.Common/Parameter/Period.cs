using System;

namespace Bm2s.Poco.Common.Parameter
{
  public class Period
  {
    public int Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public int Interval { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public Unit Unit { get; set; }
  }
}
