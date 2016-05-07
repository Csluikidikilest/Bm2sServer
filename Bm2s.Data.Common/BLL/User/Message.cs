using System;
using System.ComponentModel.DataAnnotations;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.User
{
  [Alias("Mess")]
  public class Message : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Required]
    [StringLength(250)]
    public string Subject { get; set; }

    public DateTime SendDate { get; set; }

    public DateTime? DeletionDate { get; set; }

    public bool IsShortMessage { get; set; }

    [Required]
    public string Body { get; set; }

    [Alias("UserId")]
    [References(typeof(User))]
    public int UserId { get; set; }
  }
}
