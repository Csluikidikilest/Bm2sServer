using System.Data;
using Bm2s.Data.POS.BLL.PointOfSale;
using Bm2s.Data.Utils.BLL;

namespace Bm2s.Data.POS.Utils
{
  public class DataStorage : Bm2s.Data.Utils.DataStorage
  {
    public Table<Button> Buttons { get; set; }
    public Table<Screen> Screens { get; set; }

    public DataStorage(bool ramStorage, IDbConnection dbConnection)
      : base(ramStorage, dbConnection)
    {
      this.Buttons = new Table<Button>(this._ramStorage, this._dbConnection);
      this.Screens = new Table<Screen>(this._ramStorage, this._dbConnection);
    }
  }
}
