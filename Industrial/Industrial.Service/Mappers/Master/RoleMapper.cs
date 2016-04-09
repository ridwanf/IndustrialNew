using System.Collections.Generic;
using System.Linq;
using Industrial.Data.Domain;
using Industrial.Service.ViewModel.Master;

namespace Industrial.Service.Mappers.Master
{
    public static class RoleMapper
    {
        #region convert to model
        public static RoleModel ConvertToModel(this Role data)
        {
            var model = new RoleModel();
            model.CreatedDate = data.CreatedDate;
            model.Id = data.Id;
            model.IsActive = data.IsActive;
            model.Name = data.Name;

            return model;
        }

        public static IEnumerable<RoleModel> ConvertToListModel(this IEnumerable<Role> listData)
        {
            return listData.Select(ConvertToModel).ToList();
        }
        #endregion

        #region convert to model
        public static Role ConvertToData(this RoleModel model)
        {
            var data = new Role();
            data.CreatedDate = model.CreatedDate;
            data.Id = model.Id;
            data.IsActive = model.IsActive;
            return data;
        }

        public static IEnumerable<Role> ConvertToListData(this IEnumerable<RoleModel> listData)
        {
            return listData.Select(ConvertToData).ToList();
        }
        #endregion
    }
}