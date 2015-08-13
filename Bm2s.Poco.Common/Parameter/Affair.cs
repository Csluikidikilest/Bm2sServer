
namespace Bm2s.Poco.Common.Parameter
{
  public class Affair
  {
    public int Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public Activity Activity { get; set; }

    public User.User User { get; set; }
  }
}
