using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Partner
{
  public class PartnerFile : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    public Byte[] File { get; set; }

    public DateTime AddingDate { get; set; }

    [References(typeof(Partner))]
    public int PartnerId { get; set; }

    [References(typeof(User.User))]
    public int UserId { get; set; }
  }
}
