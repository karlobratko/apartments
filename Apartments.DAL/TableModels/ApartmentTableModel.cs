﻿using System;

using Apartments.DAL.Base.TableModels;

namespace Apartments.DAL.TableModels {
  public class ApartmentTableModel : BaseTableModel<Int32> {
    public Int32 OwnerFK { get; set; }
    public Int32 StatusFK { get; set; }
    public String Name { get; set; }
    public String NameEng { get; set; }
    public Int32 CityFK { get; set; }
    public String Address { get; set; }
    public Decimal Price { get; set; }
    public Int32 MaxAdults { get; set; }
    public Int32 MaxChildren { get; set; }
    public Int32 TotalRooms { get; set; }
    public Int32 BeachDistance { get; set; }
  }
}
