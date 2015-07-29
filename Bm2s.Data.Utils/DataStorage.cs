using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Data.Utils.BLL;

namespace Bm2s.Data.Utils
{
  public class DataStorage
  {
    protected IDbConnection _dbConnection;
    protected bool _ramStorage;

    public DataStorage(bool ramStorage, IDbConnection dbConnection)
    {
      this._dbConnection = dbConnection;
      this._ramStorage = ramStorage;
    }

    public virtual void LazyLoad()
    {
    }
  }
}
