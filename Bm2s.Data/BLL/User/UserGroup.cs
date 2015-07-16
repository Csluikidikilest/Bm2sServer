using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.User
{
  public class UserGroup : Table
  {
    [References(typeof(User))]
    public int UserId { get; set; }

    [Ignore]
    public User User { get; set; }

    [References(typeof(Group))]
    public int GroupId { get; set; }

    [Ignore]
    public Group Group { get; set; }
  }
}
