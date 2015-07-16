using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL
{
  public class Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; protected set; }
  }
}
