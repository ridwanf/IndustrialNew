using Industrial.Data.Domain;
using Industrial.Data.Repositories;

namespace Industrial.Repository.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository {
        public override void SoftDelete(Supplier entity)
        {
            entity.IsActive = false;
            Update(entity);
        }
    }
}