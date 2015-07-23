using ServiceStack.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.Utils;

namespace Bm2s.Data.Common.BLL.User
{
  public class UserModule : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public bool Granted { get; set; }

    [References(typeof(User))]
    public int UserId { get; set; }

    [Ignore]
    public User User { get; set; }

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
      this.User = Datas.Instance.DataStorage.Users.FirstOrDefault<User>(item => item.Id == this.UserId);
      this.Module = Datas.Instance.DataStorage.Modules.FirstOrDefault<Module>(item => item.Id == this.ModuleId);
      this.Grantor = Datas.Instance.DataStorage.Users.FirstOrDefault<User>(item => item.Id == this.GrantorId);
    }
  }
}
