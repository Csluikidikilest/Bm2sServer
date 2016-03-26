using System.ComponentModel.DataAnnotations;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Partner
{
  public class Address : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

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
