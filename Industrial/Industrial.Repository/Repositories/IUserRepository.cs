using Core;
using Industrial.Data.Domain;
using Industrial.Data.Repositories;

namespace Industrial.Repository.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }

    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public override void SoftDelete(User entity)
        {
            entity.IsActive = false;
            entity.Roles.Clear();
            Update(entity);
        }
    }
}