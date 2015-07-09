using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Partner
{
  public class AddressLine
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    public int Order { get; set; }

    [Required]
    public string Line { get; set; }

    [References(typeof(Address))]
    public int AddressId { get; set; }

    [ForeignKey("AddressId")]
    public Address Address { get; set; }
  }
}
