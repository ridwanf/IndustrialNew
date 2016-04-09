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
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;


        public SupplierService(ISupplierRepository supplierRepository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _supplierRepository = supplierRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }
        public Task<List<SupplierModel>> GetAllAsync()
        {
            return Task.Run(() => GetAll());
        }

        public List<SupplierModel> GetAll()
        {
            List<Supplier> data = _supplierRepository.FindAll(a => a.IsActive).ToList();

            return data.ConvertToListModel().ToList();
        }


        public Task<List<SupplierModel>> GetAllAsync(int skip, int pageSize)
        {
            return Task.Run(() => GetAll(skip, pageSize));
        }

        public List<SupplierModel> GetAll(int skip, int pageSize)
        {
            var data = _supplierRepository.FindAll(a => a.IsActive).OrderByDescending(a => a.Id).Skip((skip - 1) * pageSize).Take(pageSize);

            return data.ConvertToListModel().ToList();
        }


        public Task<SupplierModel> FindByIdAsync(int id)
        {
            return Task.Run(() => FindById(id));
        }
        public SupplierModel FindById(int id)
        {
            var result = _supplierRepository.FindBy(a => a.Id == id).First();
            if (result != null)
            {
                return result.ConvertToModel();
            }
            return null;
        }

        public async Task<SupplierModel> CreateAsync(SupplierModel item)
        {
            await Task.Run(() => Create(item));
            return item;
        }

        private SupplierModel Create(SupplierModel item)
        {
            var data = item.ConvertToData();
            using (_unitOfWorkFactory.Create())
            {
                _supplierRepository.Add(data);
            }


            return data.ConvertToModel();
        }

        public async Task<SupplierModel> EditAsync(SupplierModel item)
        {
            await Task.Run(() => Edit(item));
            return item;
        }

        public SupplierModel Edit(SupplierModel item)
        {
            var data = item.ConvertToData();
            using (_unitOfWorkFactory.Create())
            {
                _supplierRepository.Update(data);
            }
            return data.ConvertToModel();
        }

        public async Task<SupplierModel> DeleteAsync(int id)
        {
            var item = await Task.Run(() => Delete(id));
            return item;
        }

        public IEnumerable<SupplierModel> Search(string searchWord, int i, int pageSize, out int total)
        {
            var data = _supplierRepository
                .FindBy(a => (a.IsActive) && (a.Name.Contains(searchWord))).OrderByDescending(a => a.Id).Skip((i - 1) * pageSize).Take(pageSize);
            total = data.Count();
            return data.ConvertToListModel();
        }

        public SupplierModel Delete(int id)
        {
            var item = _supplierRepository.FindBy(a => a.Id == id).FirstOrDefault();
            if (item == null)
                return null;
            else
            {
                using (_unitOfWorkFactory.Create())
                {
                    _supplierRepository.SoftDelete(item);

                }
                return item.ConvertToModel();
            }
        }
    }
}