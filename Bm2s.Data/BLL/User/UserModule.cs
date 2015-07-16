using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.User
{
  public class UserModule : Table
  {
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
  }
}
