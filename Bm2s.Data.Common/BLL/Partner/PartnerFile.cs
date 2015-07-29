using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Partner
{
  public class PartnerFile : Table
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

    [Ignore]
    public Partner Partner { get; set; }

    [References(typeof(User.User))]
    public int UserId { get; set; }

    [Ignore]
    public User.User User { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.Partner = Datas.Instance.DataStorage.Partners.FirstOrDefault<Partner>(item => item.Id == this.PartnerId);
      this.User = Datas.Instance.DataStorage.Users.FirstOrDefault<User.User>(item => item.Id == this.UserId);
    }
  }
}
