using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bm2s.Data.BLL.Partner
{
  public class PartnerContact
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [Required]
    [StringLength(200)]
    public string LastName { get; set; }

    [StringLength(200)]
    public string FirstName { get; set; }

    [StringLength(200)]
    public string Function { get; set; }

    [StringLength(20)]
    public string PhoneNumber { get; set; }

    [StringLength(20)]
    public string MobilePhoneNumber { get; set; }

    [StringLength(20)]
    public string FaxNumber { get; set; }

    [StringLength(255)]
    public string Email { get; set; }

    public string Observation { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [References(typeof(Partner))]
    public int PartnerId { get; set; }
  }
}
