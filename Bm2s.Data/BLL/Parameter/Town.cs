using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class Town : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [StringLength(50)]
    public string ZipCode { get; set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [References(typeof(Country))]
    public int CountryId { get; set; }

    [Ignore]
    public Country Country { get; set; }
  }
}
