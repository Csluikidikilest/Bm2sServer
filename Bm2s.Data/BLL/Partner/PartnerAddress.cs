using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Partner
{
  public class PartnerAddress
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [References(typeof(Address))]
    public int AddressId { get; set; }

    [References(typeof(AddressType))]
    public int AddressTypeId { get; set; }

    [References(typeof(Partner))]
    public int PartnerId { get; set; }
  }
}
