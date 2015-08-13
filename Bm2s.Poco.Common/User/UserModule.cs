
namespace Bm2s.Poco.Common.User
{
  public class UserModule
  {
    public int Id { get; set; }

    public bool Granted { get; set; }

    public User User { get; set; }

    public Module Module { get; set; }

    public User Grantor { get; set; }
  }
}
