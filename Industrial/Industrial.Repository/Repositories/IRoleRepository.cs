using System.Linq;
using Core;
using Industrial.Data.Domain;
using Industrial.Data.Repositories;

namespace Industrial.Repository.Repositories
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
    }

    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public override void SoftDelete(Role entity)
        {
            entity.IsActive = false;
            entity.Users.Clear();
            //foreach (var user in entity.Users)
            //{
            //    user.Roles.Remove(entity);
            //}
            Update(entity);
        }
    }
}