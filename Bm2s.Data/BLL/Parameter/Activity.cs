using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class Activity : Table
  {
    [Required]
    [StringLength(250)]
    public string CompanyName { get; set; }

    public string Address1 { get; set; }

    public string Address2 { get; set; }

    public string Address3 { get; set; }

    [StringLength(50)]
    public string TownZipCode { get; set; }

    [StringLength(250)]
    public string TownName { get; set; }

    [StringLength(250)]
    public string CountryName { get; set; }
  }
}
