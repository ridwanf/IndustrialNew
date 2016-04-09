using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Industrial.Data.Domain;
using Industrial.Repository.Repositories;
using Industrial.Service.Mappers.Master;
using Industrial.Service.ViewModel.Master;

namespace Industrial.Service.Services
{
    public class UnitOfMeasureService : IUnitOfMeasureService
    {
        private readonly IUnitOfMeasureRepository _repository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public UnitOfMeasureService(IUnitOfMeasureRepository  repository,IUnitOfWorkFactory unitOfWorkFactory)
        {
            _repository = repository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }
        public Task<List<UnitOfMeasureModel>> GetAllAsync()
        {
            return Task.Run(() => GetAll());
        }

        public List<UnitOfMeasureModel> GetAll()
        {
            List<UnitOfMeasure> data = _repository.FindAll(a => a.IsActive).ToList();

            return data.ConvertToListModel().ToList();
        }

        public Task<UnitOfMeasureModel> FindByIdAsync(int id)
        {
            return Task.Run(() => FindById(id));
        }
        public UnitOfMeasureModel FindById(int id)
        {
            var result = _repository.FindBy(a => a.Id == id).First();
            if (result != null)
            {
                return result.ConvertToModel();
            }
            return null;
        }

        public Task<List<UnitOfMeasureModel>> GetAllAsync(int skip, int pageSize)
        {
            return Task.Run(() => GetAll(skip, pageSize));
        }

        public List<UnitOfMeasureModel> GetAll(int page, int pageSize)
        {
            var data = _repository.FindAll(a => a.IsActive).OrderByDescending(a => a.Id).Skip((page - 1) * pageSize).Take(pageSize);

            return data.ConvertToListModel().ToList();
        }

        public async Task<UnitOfMeasureModel> CreateAsync(UnitOfMeasureModel item)
        {
            await Task.Run(() => Create(item));
            return item;
        }

        private UnitOfMeasureModel Create(UnitOfMeasureModel item)
        {
            var data = item.ConvertToData();
            using (_unitOfWorkFactory.Create())
            {
                _repository.Add(data);
            }


            return data.ConvertToModel();
        }

        public async Task<UnitOfMeasureModel> EditAsync(UnitOfMeasureModel item)
        {
            await Task.Run(() => Edit(item));
            return item;
        }

        public UnitOfMeasureModel Edit(UnitOfMeasureModel item)
        {
            var data = item.ConvertToData();
            using (_unitOfWorkFactory.Create())
            {
                _repository.Update(data);
            }
            return data.ConvertToModel();
        }


        public async Task<UnitOfMeasureModel> DeleteAsync(int id)
        {
            var item = await Task.Run(() => Delete(id));
            return item;
        }

        public IEnumerable<UnitOfMeasureModel> Search(string searchWord, int i, int pageSize, out int total)
        {
            var data = _repository
                    .FindBy(a => (a.IsActive) && (a.Name.Contains(searchWord))).OrderByDescending(a => a.Id).Skip((i - 1) * pageSize).Take(pageSize);
            total = data.Count();
            return data.ConvertToListModel();
        }

        public UnitOfMeasureModel Delete(int id)
        {
            var item = _repository.FindBy(a => a.Id == id).FirstOrDefault();
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