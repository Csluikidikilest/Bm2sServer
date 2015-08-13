using System;

namespace Bm2s.Poco.Common.Partner
{
  public class PartnerContact
  {
    public int Id { get; set; }

    public string LastName { get; set; }

    public string FirstName { get; set; }

    public string Function { get; set; }

    public string PhoneNumber { get; set; }

    public string MobilePhoneNumber { get; set; }

    public string FaxNumber { get; set; }

    public string Email { get; set; }

    public string Observation { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public Partner Partner { get; set; }
  }
}
