using System.Collections.Generic;
using System.Threading.Tasks;
using Industrial.Service.ViewModel.Master;

namespace Industrial.Service.Services
{
    public interface IBranchService : IBaseService<BranchModel,int>
    {
        Task<IEnumerable<BranchModel>> GetDropDownAsync(int id);
    }
}