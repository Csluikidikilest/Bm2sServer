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
  public class AddressType
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [InverseProperty("AddressType")]
    public List<PartnerAddress> PartnerAddresses { get; set; }

    [InverseProperty("AddressType")]
    public List<HeaderPartnerAddress> HeaderPartnerAddresses { get; set; }
  }
}
