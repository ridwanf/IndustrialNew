using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Industrial.Data.Domain;
using Industrial.Service.ViewModel.Master;

namespace Industrial.Service.Mappers.Master
{
    public static class ItemProductMapper
    {
        #region convert to model
        public static ItemProductModel ConvertToModel(this ItemProduct data)
        {
            var model = new ItemProductModel();
            model.CreatedDate = data.CreatedDate;
            model.Description = data.Description;
            model.Id = data.Id;
            model.IsActive = data.IsActive;
            model.Name = data.Name;
            model.Price = data.Price;
            model.Quantity = data.Quantity;

            return model;
        }

        public static IEnumerable<ItemProductModel> ConvertToListModel(this IEnumerable<ItemProduct> listData)
        {
            return listData.Select(model => ConvertToModel(model)).ToList();
        }
        #endregion

        #region convert to data
        public static ItemProduct ConvertToData(this ItemProductModel data)
        {
            var model = new ItemProduct();
            model.CreatedDate = data.CreatedDate;
            model.Description = data.Description;
            model.Id = data.Id;
            model.IsActive = data.IsActive;
            model.Name = data.Name;
            model.Price = data.Price;
            model.Quantity = data.Quantity;

            return model;
        }

        public static IEnumerable<ItemProduct> ConvertToListData(this IEnumerable<ItemProductModel> listData)
        {
            return listData.Select(model => ConvertToData(model)).ToList();
        }
        #endregion
    }
}
