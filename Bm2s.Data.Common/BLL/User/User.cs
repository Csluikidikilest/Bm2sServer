using System;
using System.ComponentModel.DataAnnotations;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.User
{
  public class User : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Required]
    [StringLength(250)]
    public string LastName { get; set; }

    [StringLength(250)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(250)]
    public string Login { get; set; }

    [Required]
    [StringLength(250)]
    public string Password { get; set; }

    public bool IsAdministrator { get; set; }

    public bool IsAnonymous { get; set; }

    public bool IsSystem { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [References(typeof(Parameter.Lang))]
    public int DelaId { get; set; }
  }
}
