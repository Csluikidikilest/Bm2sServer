using System;

namespace Bm2s.Poco.Common.Parameter
{
  public class Vat
  {
    public int Id { get; set; }

    public string Code { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public decimal Rate { get; set; }

    public string AccountingEntry { get; set; }
  }
}
