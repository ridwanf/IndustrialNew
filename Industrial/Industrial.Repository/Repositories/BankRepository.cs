using Industrial.Data.Domain;
using Industrial.Data.Repositories;

namespace Industrial.Repository.Repositories
{
    public class BankRepository : BaseRepository<Bank>, IBankRepository
    {
        public override void SoftDelete(Bank entity)
        {
            entity.IsActive = false;
            Update(entity);
        }
    }
}