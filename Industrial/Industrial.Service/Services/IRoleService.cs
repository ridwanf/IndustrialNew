using System;
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
    public interface IRoleService : IBaseService<RoleModel, Guid>
    {
    }

    public class RoleService : IRoleService
    {

        private readonly IRoleRepository _repository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public RoleService(IRoleRepository repository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _repository = repository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public Task<List<RoleModel>> GetAllAsync()
        {
            return Task.Run(() => GetAll());
        }

        public List<RoleModel> GetAll()
        {
            List<Role> data = _repository.FindAll(a => a.IsActive).ToList();
            return data.ConvertToListModel().ToList();
        }

        public Task<RoleModel> FindByIdAsync(Guid id)
        {
            return Task.Run(() => FindById(id));
        }
        public RoleModel FindById(Guid id)
        {
            var result = _repository.FindBy(a => a.Id == id).First();
            if (result != null)
            {
                return result.ConvertToModel();
            }
            return null;
        }

        public Task<List<RoleModel>> GetAllAsync(int skip, int pageSize)
        {
            return Task.Run(() => GetAll(skip, pageSize));
        }

        public List<RoleModel> GetAll(int page, int pageSize)
        {
            var data = _repository.FindAll(a => a.IsActive).OrderByDescending(a => a.Id).Skip((page - 1) * pageSize).Take(pageSize);

            return data.ConvertToListModel().ToList();
        }

        public async Task<RoleModel> CreateAsync(RoleModel item)
        {
            await Task.Run(() => Create(item));
            return item;
        }

        private RoleModel Create(RoleModel item)
        {
            var data = item.ConvertToData();
            using (_unitOfWorkFactory.Create())
            {
                _repository.Add(data);
            }


            return data.ConvertToModel();
        }

        public async Task<RoleModel> EditAsync(RoleModel item)
        {
            await Task.Run(() => Edit(item));
            return item;
        }

        public RoleModel Edit(RoleModel item)
        {
            var data = item.ConvertToData();
            using (_unitOfWorkFactory.Create())
            {
                _repository.Update(data);
            }
            return data.ConvertToModel();
        }


        public async Task<RoleModel> DeleteAsync(Guid id)
        {
            var item = await Task.Run(() => Delete(id));
            return item;
        }

        public IEnumerable<RoleModel> Search(string searchWord, int i, int pageSize, out int total)
        {
            var data = _repository
                .FindBy(a => (a.IsActive) && (a.Name.Contains(searchWord))).OrderByDescending(a => a.Id).Skip((i - 1) * pageSize).Take(pageSize);
            total = data.Count();
            return data.ConvertToListModel();
        }

        public Task<IEnumerable<RoleModel>> GetDropDownAsync(Guid id)
        {
            return Task.Run(() => GetAll().Where(a => a.Id != id));
        }

        public RoleModel Delete(Guid id)
        {
            var item = _repository.FindBy(a => a.Id == id).Include(a=>a.Users).FirstOrDefault();
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