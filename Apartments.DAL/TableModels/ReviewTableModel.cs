using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Apartments.DAL.Base.TableModels;

namespace Apartments.DAL.TableModels {
  public class ReviewTableModel : BaseTableModel<Int32> {
    public Int32 ApartmentFK { get; set; }
    public Int32 UserFK { get; set; }
    public String Details { get; set; }
    public Int32 Stars { get; set; }
  }
}
