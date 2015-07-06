using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Parameter
{
  public class Affair
  {
    public int Id { get; private set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public Activity Activity { get; set; }
    public List<AffairFile> AffairFiles { get; set; }
    public List<AffairHeader> AffairHeaders { get; set; }
    public User.User User { get; set; }
  }
}
