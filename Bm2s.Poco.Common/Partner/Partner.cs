using System;

namespace Bm2s.Poco.Common.Partner
{
  public class Partner
  {
    public int Id { get; set; }

    public string Code { get; set; }

    public string CompanyName { get; set; }

    public string PhoneNumber { get; set; }

    public string FaxNumber { get; set; }

    public string WebSite { get; set; }

    public string CompanyIdentifier { get; set; }

    public string Email { get; set; }

    public string Observation { get; set; }

    public decimal? PriceMultiplier { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public bool IsCustomer { get; set; }

    public bool IsSupplier { get; set; }

    public User.User User { get; set; }
  }
}
