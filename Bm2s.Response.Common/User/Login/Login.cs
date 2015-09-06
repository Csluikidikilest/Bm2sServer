using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.User.Login
{
  [Route("/bm2s/login/{Login}/{Password}", Verbs = "GET")]
  public class Login : Request, IReturn<LoginResponse>
  {
    public Login()
    {
    }

    public string UserLogin { get; set; }

    public string Password { get; set; }
  }
}
