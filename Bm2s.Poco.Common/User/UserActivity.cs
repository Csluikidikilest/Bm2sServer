using Bm2s.Poco.Common.Parameter;

namespace Bm2s.Poco.Common.User
{
  public class UserActivity
  {
    public int Id { get; set; }

    public bool IsDefault { get; set; }

    public Activity Activity { get; set; }

    public User User { get; set; }
  }
}
