using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Industrial.Data.Domain;
using Industrial.Models.Interfaces;
using Industrial.Repository.Repositories;
using Industrial.Service.Mappers.Master;
using Industrial.Service.ViewModel.Master;

namespace Industrial.Service.Services
{
    public class UserService : IUserService
    {
       
        private readonly IUserRepository _repository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public UserService(IUserRepository repository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _repository = repository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public Task<List<UserModel>> GetAllAsync()
        {
            return Task.Run(() => GetAll());
        }

        public List<UserModel> GetAll()
        {
            List<User> data = _repository.FindAll(a => a.IsActive).Include(a=>a.Roles).ToList();
            return data.ConvertToListModel().ToList();
        }

        public Task<UserModel> FindByIdAsync(Guid id)
        {
            return Task.Run(() => FindById(id));
        }
        public UserModel FindById(Guid id)
        {
            var result = _repository.FindBy(a => a.Id == id).Include(a=>a.Roles).First();
            if (result != null)
            {
                return result.ConvertToModel();
            }
            return null;
        }

        public Task<List<UserModel>> GetAllAsync(int skip, int pageSize)
        {
            return Task.Run(() => GetAll(skip, pageSize));
        }

        public List<UserModel> GetAll(int page, int pageSize)
        {
            var data = _repository.FindAll(a => a.IsActive).OrderByDescending(a => a.Id).Skip((page - 1) * pageSize).Take(pageSize);

            return data.ConvertToListModel().ToList();
        }

        public async Task<UserModel> CreateAsync(UserModel item)
        {
            await Task.Run(() => Create(item));
            return item;
        }

        private UserModel Create(UserModel item)
        {
            var data = item.ConvertToData();
            using (_unitOfWorkFactory.Create())
            {
                _repository.Add(data);
            }


            return data.ConvertToModel();
        }

        public async Task<UserModel> EditAsync(UserModel item)
        {
            await Task.Run(() => Edit(item));
            return item;
        }

        public UserModel Edit(UserModel item)
        {
            var data = item.ConvertToData();
            using (_unitOfWorkFactory.Create())
            {
                _repository.Update(data);
            }
            return data.ConvertToModel();
        }


        public async Task<UserModel> DeleteAsync(Guid id)
        {
            var item = await Task.Run(() => Delete(id));
            return item;
        }

        public IEnumerable<UserModel> Search(string searchWord, int i, int pageSize, out int total)
        {
            var data = _repository
                .FindBy(a => (a.IsActive) && (a.UserName.Contains(searchWord))).OrderByDescending(a => a.Id).Skip((i - 1) * pageSize).Take(pageSize);
            total = data.Count();
            return data.ConvertToListModel();
        }

        public Task<IEnumerable<UserModel>> GetDropDownAsync(Guid id)
        {
            return Task.Run(() => GetAll().Where(a=>a.Id!=id));
        }

        public UserModel Delete(Guid id)
        {
            var item = _repository.FindBy(a => a.Id == id).Include(a=>a.Roles).FirstOrDefault();
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