
namespace Bm2s.Poco.Common.User
{
  public class GroupModule
  {
    public int Id { get; set; }

    public bool Granted { get; set; }

    public Group Group { get; set; }

    public Module Module { get; set; }

    public User Grantor { get; set; }
  }
}
