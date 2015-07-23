using ServiceStack.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.Utils;

namespace Bm2s.Data.Common.BLL.User
{
  public class GroupModule : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public bool Granted { get; set; }

    [References(typeof(Group))]
    public int GroupId { get; set; }

    [Ignore]
    public Group Group { get; set; }

    [References(typeof(Module))]
    public int ModuleId { get; set; }

    [Ignore]
    public Module Module { get; set; }

    [References(typeof(User))]
    public int GrantorId { get; set; }

    [Ignore]
    public User Grantor { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.Group = Datas.Instance.DataStorage.Groups.FirstOrDefault<Group>(item => item.Id == this.GroupId);
      this.Module = Datas.Instance.DataStorage.Modules.FirstOrDefault<Module>(item => item.Id == this.ModuleId);
      this.Grantor = Datas.Instance.DataStorage.Users.FirstOrDefault<User>(item => item.Id == this.GrantorId);
    }
  }
}
