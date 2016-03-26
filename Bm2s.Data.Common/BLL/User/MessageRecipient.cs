using System;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.User
{
  public class MessageRecipient : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public DateTime ReadingDate { get; set; }

    [References(typeof(Message))]
    public int MessageId { get; set; }

    [References(typeof(User))]
    public int UserId { get; set; }
  }
}
