using System;

using Apartments.BLL.DomainModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Base.Managers.DomainModels {
  public interface ITagTypeDomainModelManager : IDomainModelManager<Int32, TagTypeTableModel, TagTypeDomainModel> {
  }
}
