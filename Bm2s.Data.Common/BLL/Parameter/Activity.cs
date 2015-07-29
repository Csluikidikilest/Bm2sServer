using System.ComponentModel.DataAnnotations;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class Activity : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

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
