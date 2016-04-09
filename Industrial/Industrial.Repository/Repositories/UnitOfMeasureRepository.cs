using Industrial.Data.Domain;
using Industrial.Data.Repositories;

namespace Industrial.Repository.Repositories
{
    public class UnitOfMeasureRepository : BaseRepository<UnitOfMeasure>,IUnitOfMeasureRepository
    {
        public override void SoftDelete(UnitOfMeasure entity)
        {
            entity.IsActive = false;
            Update(entity);
        }
    }
}