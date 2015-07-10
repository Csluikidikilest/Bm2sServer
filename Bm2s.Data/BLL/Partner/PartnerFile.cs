using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bm2s.Data.BLL.Partner
{
  public class PartnerFile
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    public Byte[] File { get; set; }

    public DateTime AddingDate { get; set; }

    [References(typeof(Partner))]
    public int PartnerId { get; set; }

    [ForeignKey("PartnerId")]
    public Partner Partner { get; set; }

    [References(typeof(User.User))]
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public User.User User { get; set; }
  }
}
