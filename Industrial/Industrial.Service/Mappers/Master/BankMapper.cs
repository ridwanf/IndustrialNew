using System.Collections.Generic;
using System.Linq;
using Industrial.Data.Domain;
using Industrial.Service.ViewModel.Master;

namespace Industrial.Service.Mappers.Master
{
    public static class BankMapper
    {
        #region convert to model
        public static BankModel ConvertToModel(this Bank data)
        {
            var model = new BankModel();
            model.CreatedDate = data.CreatedDate;
            model.Id = data.Id;
            model.IsActive = data.IsActive;
            model.Name = data.Name;
            model.Code = data.Code;
          

            return model;
        }

        public static IEnumerable<BankModel> ConvertToListModel(this IEnumerable<Bank> listData)
        {
            return listData.Select(model => ConvertToModel(model)).ToList();
        }
        #endregion

        #region convert to data
        public static Bank ConvertToData(this BankModel data)
        {
            var model = new Bank();
            model.CreatedDate = data.CreatedDate;
            model.Id = data.Id;
            model.IsActive = data.IsActive;
            model.Name = data.Name;
            model.Code = data.Code;

            return model;
        }

        public static IEnumerable<Bank> ConvertToListData(this IEnumerable<BankModel> listData)
        {
            return listData.Select(model => ConvertToData(model)).ToList();
        }
        #endregion
    }
}