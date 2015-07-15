using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Data.BLL.Parameter;
using Bm2s.Data.BLL.Partner;
using Bm2s.Data.BLL.Trade;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.User
{
  public class User
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [Required]
    [StringLength(250)]
    public string LastName { get; set; }

    [Required]
    [StringLength(250)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(250)]
    public string Login { get; set; }

    [Required]
    [StringLength(250)]
    public string Password { get; set; }

    public bool IsAdministrator { get; set; }

    public bool IsAnonymous { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }
  }
}
