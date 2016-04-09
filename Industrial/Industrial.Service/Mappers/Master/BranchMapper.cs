using System.Collections.Generic;
using System.Linq;
using Industrial.Data.Domain;
using Industrial.Service.ViewModel.Master;

namespace Industrial.Service.Mappers.Master
{
    public static class BranchMapper
    {
        #region convert to model
        public static BranchModel ConvertToModel(this Branch data)
        {
            var model = new BranchModel();
            model.CreatedDate = data.CreatedDate;
            model.Id = data.Id;
            model.IsActive = data.IsActive;
            model.Name = data.Name;
          //  model.Children = (data.Children != null) ? data.Children.ConvertToListModel() : null;
            model.ParentBranchId = (data.ParentBranch != null) ? data.ParentBranch.Id : (int?) null;
            model.ParentBranchName = (data.ParentBranch != null) ? data.ParentBranch.Name:null;

            return model;
        }

        public static IEnumerable<BranchModel> ConvertToListModel(this IEnumerable<Branch> listData)
        {
            return listData.Select(ConvertToModel).ToList();
        }
        #endregion

        #region convert to data
        public static Branch ConvertToData(this BranchModel data)
        {
            var model = new Branch();
            model.CreatedDate = data.CreatedDate;
            model.Id = data.Id;
            model.IsActive = data.IsActive;
            model.Name = data.Name;
 //           model.Children = (data.Children!=null)?(ICollection<Branch>)data.Children.ConvertToListData():null;
            model.ParentBranchId = data.ParentBranchId;
        //    model.ParentBranch = (data.ParentBranch != null) ? data.ParentBranch.ConvertToData() : null;
            return model;
        }

        public static IEnumerable<Branch> ConvertToListData(this IEnumerable<BranchModel> listData)
        {
            return listData.Select(ConvertToData).ToList();
        }
        #endregion
    }
}