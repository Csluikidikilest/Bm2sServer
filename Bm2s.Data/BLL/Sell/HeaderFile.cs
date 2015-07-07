using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Sell
{
  public class HeaderFile
  {
    [AutoIncrement] [PrimaryKey] public int Id { get; private set; }
    public string Name { get; set; }
    public Byte[] File { get; set; }
    public DateTime AddingDate { get; set; }
    public Header Header { get; set; }
    public User.User User { get; set; }
  }
}
