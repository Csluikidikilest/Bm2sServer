using Bm2s.Data.BLL.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bm2s.Data.BLL.User
{
  public class UserActivity
  {
    public bool IsDefault { get; set; }

    [References(typeof(Activity))]
    public int ActivityId { get; set; }

    [ForeignKey("ActivityId")]
    public Activity Activity { get; set; }

    [References(typeof(User))]
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
  }
}
