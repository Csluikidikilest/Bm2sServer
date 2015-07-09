using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class AffairFile
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    public Byte[] File { get; set; }

    public DateTime AddingDate { get; set; }

    [References(typeof(Affair))]
    public int AffairId { get; set; }

    [ForeignKey("AffairId")]
    public Affair Affair { get; set; }

    [References(typeof(User.User))]
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public User.User User { get; set; }
  }
}
