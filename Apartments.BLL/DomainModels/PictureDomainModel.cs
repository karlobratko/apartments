using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Apartments.BLL.Base.DomainModels;

namespace Apartments.BLL.DomainModels {
  public class PictureDomainModel : BaseDomainModel<Int32> {
    public Int32 ApartmentFK { get; set; }
    public String Title { get; set; }
    public String Path { get; set; }
    public Boolean IsRepresentative { get; set; }
  }
}
