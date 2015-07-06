using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Partner
{
  public class PartnerFile
  {
    public int Id { get; private set; }
    public string Name { get; set; }
    public Byte[] File { get; set; }
    public DateTime AddingDate { get; set; }
    public Partner Partner { get; set; }
    public User.User User { get; set; }
  }
}
