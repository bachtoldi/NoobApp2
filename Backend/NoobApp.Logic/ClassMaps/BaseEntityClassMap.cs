using FluentNHibernate.Mapping;
using NoobApp.Logic.Entities;

namespace NoobApp.Logic.ClassMaps {
  public class BaseEntityClassMap<T> : ClassMap<BaseEntity> where T : BaseEntity {
    public BaseEntityClassMap() {
      Id(i => i.Id);
    }
  }
}
