using Bm2s.Data.Common.BLL.Parameter;
using ServiceStack.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.Utils;

namespace Bm2s.Data.Common.BLL.User
{
  public class UserActivity : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public bool IsDefault { get; set; }

    [References(typeof(Activity))]
    public int ActivityId { get; set; }

    [Ignore]
    public Activity Activity { get; set; }

    [References(typeof(User))]
    public int UserId { get; set; }

    [Ignore]
    public User User { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.Activity = Datas.Instance.DataStorage.Activities.FirstOrDefault<Activity>(item => item.Id == this.ActivityId);
      this.User = Datas.Instance.DataStorage.Users.FirstOrDefault<User>(item => item.Id == this.UserId);
    }
  }
}
