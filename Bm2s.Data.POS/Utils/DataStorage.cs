using System.Data;
using Bm2s.Data.POS.BLL.PointOfSale;
using Bm2s.Data.Utils.BLL;

namespace Bm2s.Data.POS.Utils
{
  public class DataStorage : Bm2s.Data.Utils.DataStorage
  {
    public Tables<Button> Buttons { get; set; }
    public Tables<Screen> Screens { get; set; }

    public DataStorage(bool ramStorage, IDbConnection dbConnection)
      : base(ramStorage, dbConnection)
    {
      this.Buttons = new Tables<Button>(this._ramStorage, this._dbConnection);
      this.Screens = new Tables<Screen>(this._ramStorage, this._dbConnection);
    }

    public override void LazyLoad()
    {
      base.LazyLoad();

      this.Buttons.LazyLoad();
      this.Screens.LazyLoad();
    }
  }
}
