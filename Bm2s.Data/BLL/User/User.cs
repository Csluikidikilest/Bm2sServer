using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Data.BLL.Parameter;
using Bm2s.Data.BLL.Partner;
using Bm2s.Data.BLL.Trade;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.User
{
  public class User
  {
    [AutoIncrement] [PrimaryKey] public int Id { get; private set; }
    public string LastName { get; set;}
    public string FirstName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public bool IsAdministrator { get; set; }
    public bool IsAnonymous { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime? EndingDate { get; set; }
    public List<Affair> Affairs { get; set; }
    public List<AffairFile> AffairFiles { get; set; }
    public List<Partner.Partner> Partners { get; set; }
    public List<PartnerFile> PartnerFiles { get; set; }
    public List<HeaderFile> HeaderFiles { get; set; }
    public List<GroupModule> GroupModuleGrantors { get; set; }
    public List<UserActivity> UserActivities { get; set; }
    public List<UserGroup> UserGroups { get; set; }
    public List<UserModule> UserModuleGrantors { get; set; }
    public List<UserModule> UserModuleGranteds { get; set; }
  }
}
