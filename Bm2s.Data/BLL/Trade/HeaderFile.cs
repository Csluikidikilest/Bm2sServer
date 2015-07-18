using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bm2s.Data.BLL.Trade
{
  public class HeaderFile : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; protected set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    public Byte[] File { get; set; }

    public DateTime AddingDate { get; set; }

    [References(typeof(Header))]
    public int HeaderId { get; set; }

    [Ignore]
    public Header Header { get; set; }

    [References(typeof(User.User))]
    public int UserId { get; set; }

    [Ignore]
    public User.User User { get; set; }
  }
}
