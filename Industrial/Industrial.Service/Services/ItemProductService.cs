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
    public class ItemProductService : IItemProductService
    {
        MainDataContext context = new MainDataContext();
        private readonly IItemProductRepository _itemRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public ItemProductService(IItemProductRepository itemRepository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _itemRepository = itemRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public Task<List<ItemProductModel>> GetAllAsync()
        {
            return Task.Run(() => GetAll());
        }

        public List<ItemProductModel> GetAll()
        {
            List<ItemProduct> data = _itemRepository.FindAll(a => a.IsActive).ToList();

            return data.ConvertToListModel().ToList();
        }


        public Task<List<ItemProductModel>> GetAllAsync(int skip, int pageSize)
        {
            return Task.Run(() => GetAll( skip,  pageSize));
        }

        public List<ItemProductModel> GetAll(int skip, int pageSize)
        {
         var data = _itemRepository.FindAll(a => a.IsActive).OrderByDescending(a=>a.Id).Skip((skip-1)*pageSize).Take(pageSize);

            return data.ConvertToListModel().ToList();
        }


        public Task<ItemProductModel> FindByIdAsync(int id)
        {
            return Task.Run(() => FindById(id));
        }
        public ItemProductModel FindById(int id)
        {
            var result = _itemRepository.FindBy(a => a.Id == id).First();
            if (result != null)
            {
                return result.ConvertToModel();
            }
            return null;
        }

        public async Task<ItemProductModel> CreateAsync(ItemProductModel item)
        {
            await Task.Run(() => Create(item));
            return item;
        }

        private ItemProductModel Create(ItemProductModel item)
        {
           var data = item.ConvertToData();
            using (_unitOfWorkFactory.Create())
            {
                _itemRepository.Add(data);
            }

           
            return data.ConvertToModel();
        }

        public async Task<ItemProductModel> EditAsync(ItemProductModel item)
        {
            await Task.Run(() => Edit(item));
            return item;
        }

        public ItemProductModel Edit(ItemProductModel item)
        {
            var data = item.ConvertToData();
            using (_unitOfWorkFactory.Create())
            {
                _itemRepository.Update(data);
            }
            return data.ConvertToModel();
        }

        public async Task<ItemProductModel> DeleteAsync(int id)
        {
            var item = await Task.Run(() => Delete(id));
            return item;
        }

        public IEnumerable<ItemProductModel> Search(string searchWord, int i, int pageSize, out int total)
        {
            var data = _itemRepository
                .FindBy(a => (a.IsActive) && (a.Name.Contains(searchWord) || (a.Description.Contains(searchWord)))).OrderByDescending(a => a.Id).Skip((i - 1) * pageSize).Take(pageSize);
            total = data.Count();
            return data.ConvertToListModel();
        }

        public ItemProductModel Delete(int id)
        {
            var item = _itemRepository.FindBy(a => a.Id == id).FirstOrDefault();
            if (item == null)
                return null;
            else
            {
                using (_unitOfWorkFactory.Create())
                {
                    _itemRepository.SoftDelete(item);
                    
                }
                return item.ConvertToModel();
            }
        }
    }
}