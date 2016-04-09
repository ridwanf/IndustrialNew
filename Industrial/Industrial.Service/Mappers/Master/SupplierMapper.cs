using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Industrial.Data.Domain;
using Industrial.Service.ViewModel.Master;

namespace Industrial.Service.Mappers.Master
{
    public static class SupplierMapper
    {
        #region convert to model
        public static SupplierModel ConvertToModel(this Supplier data)
        {
            var model = new SupplierModel();
            model.CreatedDate = data.CreatedDate;
            model.Id = data.Id;
            model.IsActive = data.IsActive;
            model.Name = data.Name;
            model.Address = data.Address;
            model.ContractDate = data.ContractDate;
            model.Email = data.Email;
            model.Email2 = data.Email2;
            model.FaxNumber = data.FaxNumber;
            model.FaxNumber2 = data.FaxNumber2;
            model.PhoneNumber = data.PhoneNumber;
            model.PhoneNumber2 = data.PhoneNumber2;
            model.PicName = data.PicName;
            model.RegisterDate = data.RegisterDate;

            return model;
        }

        public static IEnumerable<SupplierModel> ConvertToListModel(this IEnumerable<Supplier> listData)
        {
            return listData.Select(model => ConvertToModel(model)).ToList();
        }
        #endregion

        #region convert to data
        public static Supplier ConvertToData(this SupplierModel data)
        {
            var model = new Supplier();
            model.CreatedDate = data.CreatedDate;
            model.Id = data.Id;
            model.IsActive = data.IsActive;
            model.Name = data.Name;
            model.Address = data.Address;
            model.ContractDate = data.ContractDate;
            model.Email = data.Email;
            model.Email2 = data.Email2;
            model.FaxNumber = data.FaxNumber;
            model.FaxNumber2 = data.FaxNumber2;
            model.PhoneNumber = data.PhoneNumber;
            model.PhoneNumber2 = data.PhoneNumber2;
            model.PicName = data.PicName;
            model.RegisterDate = data.RegisterDate;

            return model;
        }

        public static IEnumerable<Supplier> ConvertToListData(this IEnumerable<SupplierModel> listData)
        {
            return listData.Select(model => ConvertToData(model)).ToList();
        }
        #endregion
    }
}
