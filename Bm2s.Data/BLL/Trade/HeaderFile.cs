using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Trade
{
  public class HeaderFile
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    public Byte[] File { get; set; }

    public DateTime AddingDate { get; set; }

    [References(typeof(Header))]
    public int HeaderId { get; set; }

    [References(typeof(User.User))]
    public int UserId { get; set; }
  }
}
