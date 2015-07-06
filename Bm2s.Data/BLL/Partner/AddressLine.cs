using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Partner
{
  public class AddressLine
  {
    public int Id { get; private set; }
    public int Order { get; set; }
    public string Line { get; set; }
    public Address Address { get; set; }
  }
}
