using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.User.Login
{
  [Route("/bm2s/login/{UserLogin}/{Password}", Verbs = "GET")]
  public class Login : Request, IReturn<LoginResponse>
  {
    public Login()
    {
    }

    public string Password { get; set; }

    public string UserLogin { get; set; }
  }
}
