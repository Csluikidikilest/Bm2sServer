using System;

namespace Bm2s.Poco.Common.Article
{
  public class Brand
  {
    public int Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }
  }
}
