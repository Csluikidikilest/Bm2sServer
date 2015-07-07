using Bm2s.Data.BLL.Sell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Partner
{
  public class AddressType
  {
    [AutoIncrement] [PrimaryKey] public int Id { get; private set; }
    public string Name { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime? EndingDate { get; set; }
    public List<PartnerAddress> PartnerAddresses { get; set; }
    public List<HeaderPartnerAddress> HeaderPartnerAddresses { get; set; }
  }
}
