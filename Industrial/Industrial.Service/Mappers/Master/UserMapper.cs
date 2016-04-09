using System.Collections.Generic;
using System.Linq;
using Industrial.Data.Domain;
using Industrial.Service.ViewModel.Master;

namespace Industrial.Service.Mappers.Master
{
    public static class UserMapper
    {
        #region convert to model

        public static UserModel ConvertToModel(this User data)
        {
            var model = new UserModel();
            model.CreatedDate = data.CreatedDate;
            model.Id = data.Id;
            model.IsActive = data.IsActive;
            model.UserName = data.UserName;
            model.PasswordHash = data.PasswordHash;
            model.Roles = (data.Roles != null) ? data.Roles.ConvertToListModel() : null;

            return model;
        }

        public static IEnumerable<UserModel> ConvertToListModel(this IEnumerable<User> listData)
        {
            return listData.Select(ConvertToModel).ToList();
        }

        #endregion

        #region convert to model

        public static User ConvertToData(this UserModel model)
        {
            var data = new User();
            data.CreatedDate = model.CreatedDate;
            data.Id = model.Id;
            data.IsActive = model.IsActive;
            data.UserName = model.UserName;
            data.PasswordHash = model.PasswordHash;
            data.Roles = (ICollection<Role>) ((data.Roles != null) ? model.Roles.ConvertToListData() : null);
            return data;
        }

        public static IEnumerable<User> ConvertToListData(this IEnumerable<UserModel> listData)
        {
            return listData.Select(ConvertToData).ToList();
        }

        #endregion
    }
}