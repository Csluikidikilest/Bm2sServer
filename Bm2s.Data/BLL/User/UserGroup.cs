using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.User
{
  public class UserGroup
  {
    [References(typeof(User))]
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    [References(typeof(Group))]
    public int GroupId { get; set; }

    [ForeignKey("GroupId")]
    public Group Group { get; set; }
  }
}
