using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Services.Common.User.User
{
  [Route("/bm2s/users", Verbs = "GET, POST")]
  [Route("/bm2s/users/{Ids}", Verbs = "GET")]
  public class Users : IReturn<UsersResponse>
  {
    public Users()
    {
      this.Ids = new List<int>();
    }

    public DateTime? Date { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Login { get; set; }

    public List<int> Ids { get; set; }

    public bool IsAdministrator { get; set; }

    public bool IsAnonymous { get; set; }

    public Bm2s.Poco.Common.User.User User { get; set; }
  }
}
