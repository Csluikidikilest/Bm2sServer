using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.User
{
  public class UserGroup : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [References(typeof(User))]
    public int UserId { get; set; }

    [Ignore]
    public User User { get; set; }

    [References(typeof(Group))]
    public int GroupId { get; set; }

    [Ignore]
    public Group Group { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.User = Datas.Instance.DataStorage.Users.FirstOrDefault<User>(item => item.Id == this.UserId);
      this.Group = Datas.Instance.DataStorage.Groups.FirstOrDefault<Group>(item => item.Id == this.GroupId);
    }
  }
}
