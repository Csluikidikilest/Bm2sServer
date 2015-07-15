using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bm2s.Data.BLL.Parameter
{
  public class Town
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [StringLength(50)]
    public string ZipCode { get; set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [References(typeof(Country))]
    public int CountryId { get; set; }
  }
}
