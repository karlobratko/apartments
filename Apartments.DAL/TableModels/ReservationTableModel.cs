using System;

using Apartments.DAL.Base.TableModels;

namespace Apartments.DAL.TableModels {
  public class ReservationTableModel : BaseTableModel<Int32> {
    public Int32 ApartmentFK { get; set; }
    public String Details { get; set; }
    public Int32? UserFK { get; set; }
    public String UserFName { get; set; }
    public String UserLName { get; set; }
    public String UserEmail { get; set; }
    public String UserPhoneNumber { get; set; }
    public String UserAddress { get; set; }
  }
}
