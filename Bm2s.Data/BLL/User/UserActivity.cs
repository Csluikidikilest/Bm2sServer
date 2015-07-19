using Bm2s.Data.BLL.Parameter;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.User
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
  }
}
