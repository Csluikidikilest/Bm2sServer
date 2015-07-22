using Bm2s.Data.Common.Utils;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class Affair : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Required]
    [StringLength(250)]
    public string Code { get; set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    public string Description { get; set; }

    [References(typeof(Activity))]
    public int ActivityId { get; set; }

    [Ignore]
    public Activity Activity { get; set; }

    [References(typeof(User.User))]
    public int UserId { get; set; }

    [Ignore]
    public User.User User { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.Activity = Datas.Instance.DataStorage.Activities.FirstOrDefault<Activity>(item => item.Id == this.ActivityId);
      this.User = Datas.Instance.DataStorage.Users.FirstOrDefault<User.User>(item => item.Id == this.UserId);
    }
  }
}
