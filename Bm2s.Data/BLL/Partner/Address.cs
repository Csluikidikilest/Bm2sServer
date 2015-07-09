using Bm2s.Data.BLL.Trade;
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
  public class Address
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [Required]
    [StringLength(50)]
    public string TownZipCode { get; set; }

    [Required]
    [StringLength(250)]
    public string TownName { get; set; }

    [StringLength(250)]
    public string CountryName { get; set; }

    [InverseProperty("Address")]
    public List<AddressLine> AddressLines { get; set; }

    [InverseProperty("Address")]
    public List<PartnerAddress> PartnerAddresses { get; set; }

    [InverseProperty("Address")]
    public List<HeaderPartnerAddress> HeaderPartnerAddresses { get; set; }
  }
}
