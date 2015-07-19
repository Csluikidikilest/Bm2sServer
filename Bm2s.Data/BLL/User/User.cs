using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bm2s.Data.BLL.User
{
  public class User : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Required]
    [StringLength(250)]
    public string LastName { get; set; }

    [Required]
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

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }
  }
}
