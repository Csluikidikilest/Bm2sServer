using System;

namespace Bm2s.Poco.Common.Parameter
{
  public class Town
  {
    public int Id { get; set; }

    public string ZipCode { get; set; }

    public string Name { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public Country Country { get; set; }
  }
}
