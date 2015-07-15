using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class Affair
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [Required]
    [StringLength(250)]
    public string Code { get; set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    public string Description { get; set; }

    [References(typeof(Activity))]
    public int ActivityId { get; set; }

    [References(typeof(User.User))]
    public int UserId { get; set; }
  }
}
