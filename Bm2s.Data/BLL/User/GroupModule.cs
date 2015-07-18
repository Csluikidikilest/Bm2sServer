using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.User
{
  public class GroupModule : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; protected set; }

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
    public User User { get; set; }
  }
}
