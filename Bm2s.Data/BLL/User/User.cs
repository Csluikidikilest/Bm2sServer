using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    public string LastName { get; set; }

    public string FirstName { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public bool IsAdministrator { get; set; }

    public bool IsAnonymous { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [InverseProperty("User")]
    public List<Affair> Affairs { get; set; }

    [InverseProperty("User")]
    public List<AffairFile> AffairFiles { get; set; }

    [InverseProperty("User")]
    public List<Partner.Partner> Partners { get; set; }

    [InverseProperty("User")]
    public List<PartnerFile> PartnerFiles { get; set; }

    [InverseProperty("User")]
    public List<HeaderFile> HeaderFiles { get; set; }

    [InverseProperty("User")]
    public List<GroupModule> GroupModuleGrantors { get; set; }

    [InverseProperty("User")]
    public List<UserActivity> UserActivities { get; set; }

    [InverseProperty("User")]
    public List<UserGroup> UserGroups { get; set; }

    [InverseProperty("Grantor")]
    public List<UserModule> UserModuleGrantors { get; set; }

    [InverseProperty("User")]
    public List<UserModule> UserModuleGranteds { get; set; }
  }
}
