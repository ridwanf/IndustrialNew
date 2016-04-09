using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Industrial.Data.Domain;
using Industrial.Repository.Repositories;
using Industrial.Service.Mappers.Master;
using Industrial.Service.ViewModel.Master;

namespace Industrial.Service.Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _repository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public BranchService(IBranchRepository repository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _repository = repository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public Task<List<BranchModel>> GetAllAsync()
        {
            return Task.Run(() => GetAll());
        }

        public List<BranchModel> GetAll()
        {
            List<Branch> data = _repository.FindAll(a => a.IsActive).Include(a=>a.ParentBranch).Include(a=>a.Children).ToList();
            return data.ConvertToListModel().ToList();
        }

        public Task<BranchModel> FindByIdAsync(int id)
        {
            return Task.Run(() => FindById(id));
        }
        public BranchModel FindById(int id)
        {
            var result = _repository.FindBy(a => a.Id == id).Include(a=>a.ParentBranch)
                .Include(a=>a.Children).First();
            if (result != null)
            {
                return result.ConvertToModel();
            }
            return null;
        }

        public Task<List<BranchModel>> GetAllAsync(int skip, int pageSize)
        {
            return Task.Run(() => GetAll(skip, pageSize));
        }

        public List<BranchModel> GetAll(int page, int pageSize)
        {
            var data = _repository.FindAll(a => a.IsActive).Include(a => a.ParentBranch).OrderByDescending(a => a.Id).Skip((page - 1) * pageSize).Take(pageSize);

            return data.ConvertToListModel().ToList();
        }

        public async Task<BranchModel> CreateAsync(BranchModel item)
        {
            await Task.Run(() => Create(item));
            return item;
        }

        private BranchModel Create(BranchModel item)
        {
            var data = item.ConvertToData();
            using (_unitOfWorkFactory.Create())
            {
                _repository.Add(data);
            }


            return data.ConvertToModel();
        }

        public async Task<BranchModel> EditAsync(BranchModel item)
        {
            await Task.Run(() => Edit(item));
            return item;
        }

        public BranchModel Edit(BranchModel item)
        {
            var data = item.ConvertToData();
            using (_unitOfWorkFactory.Create())
            {
                _repository.Update(data);
            }
            return data.ConvertToModel();
        }


        public async Task<BranchModel> DeleteAsync(int id)
        {
            var item = await Task.Run(() => Delete(id));
            return item;
        }

        public IEnumerable<BranchModel> Search(string searchWord, int i, int pageSize, out int total)
        {
            var data = _repository
                .FindBy(a => (a.IsActive) && (a.Name.Contains(searchWord))).OrderByDescending(a => a.Id).Skip((i - 1) * pageSize).Take(pageSize);
            total = data.Count();
            return data.ConvertToListModel();
        }

        public Task<IEnumerable<BranchModel>> GetDropDownAsync(int id)
        {
            return Task.Run(() => GetAll().Where(a=>a.Id!=id));
        }

        public BranchModel Delete(int id)
        {
            var item = _repository.FindBy(a => a.Id == id).Include(a=>a.Children).FirstOrDefault();
            if (item == null)
                return null;
            using (_unitOfWorkFactory.Create())
            {
                _repository.SoftDelete(item);

            }
            return item.ConvertToModel();
        }
    }
}