using System;

using Apartments.BLL.DomainModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Base.Managers.DomainModels {
  public interface ITagDomainModelManager : IDomainModelManager<Int32, TagTableModel, TagDomainModel> {
  }
}
