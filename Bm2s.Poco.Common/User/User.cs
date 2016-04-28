using System;

namespace Bm2s.Poco.Common.User
{
  public class User
  {
    public int Id { get; set; }

    public string LastName { get; set; }

    public string FirstName { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public bool IsAdministrator { get; set; }

    public bool IsAnonymous { get; set; }

    public bool IsSystem { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public Parameter.Language DefaultLanguage { get; set; }
  }
}
