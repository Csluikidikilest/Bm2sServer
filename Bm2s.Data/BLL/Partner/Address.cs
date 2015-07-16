using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Bm2s.Data.BLL.Partner
{
  public class Address : Table
  {
    [Required]
    [StringLength(50)]
    public string TownZipCode { get; set; }

    [Required]
    [StringLength(250)]
    public string TownName { get; set; }

    [StringLength(250)]
    public string CountryName { get; set; }
  }
}
