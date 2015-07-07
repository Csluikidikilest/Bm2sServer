using Bm2s.Data.BLL.Sell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Partner
{
  public class Address
  {
    [AutoIncrement] [PrimaryKey] public int Id { get; private set; }
    public string TownZipCode { get; set; }
    public string TownName { get; set; }
    public string CountryName { get; set; }
    public List<AddressLine> AddressLines { get; set; }
    public List<Partner> Partners { get; set; }
    public List<PartnerAddress> PartnerAddresses { get; set; }
    public List<HeaderPartnerAddress> HeaderPartnerAddresses { get; set; }
  }
}
