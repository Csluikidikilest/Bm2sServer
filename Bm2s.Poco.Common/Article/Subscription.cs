using System;
using Bm2s.Poco.Common.Parameter;

namespace Bm2s.Poco.Common.Article
{
  public class Subscription
  {
    public int Id { get; set; }

    public string Code { get; set; }

    public string Designation { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public Article Article { get; set; }

    public Period Period { get; set; }
  }
}
