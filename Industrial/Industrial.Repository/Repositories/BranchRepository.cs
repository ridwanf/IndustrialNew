using Industrial.Data.Domain;
using Industrial.Data.Repositories;

namespace Industrial.Repository.Repositories
{
    public class BranchRepository : BaseRepository<Branch>, IBranchRepository
    {
        public override void SoftDelete(Branch entity)
        {
            entity.IsActive = false;
            foreach (var branch in entity.Children)
            {
                branch.ParentBranchId = null;
            }
            Update(entity);
        }
    }
}