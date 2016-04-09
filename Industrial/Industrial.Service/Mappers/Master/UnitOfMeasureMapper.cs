using System.Collections.Generic;
using System.Linq;
using Industrial.Data.Domain;
using Industrial.Service.ViewModel.Master;

namespace Industrial.Service.Mappers.Master
{
    public static class UnitOfMeasureMapper
    {
        #region convert to modelUnitOfMeasureModel
        public static UnitOfMeasureModel ConvertToModel(this UnitOfMeasure data)
        {
            var model = new UnitOfMeasureModel();
            model.CreatedDate = data.CreatedDate;
            model.Id = data.Id;
            model.IsActive = data.IsActive;
            model.Name = data.Name;
            model.DisplayName = data.DisplayName;

            return model;
        }

        public static IEnumerable<UnitOfMeasureModel> ConvertToListModel(this IEnumerable<UnitOfMeasure> listData)
        {
            return listData.Select(model => ConvertToModel(model)).ToList();
        }
        #endregion

        #region convert to data
        public static UnitOfMeasure ConvertToData(this UnitOfMeasureModel data)
        {
            var model = new UnitOfMeasure();
            model.CreatedDate = data.CreatedDate;
            model.Id = data.Id;
            model.IsActive = data.IsActive;
            model.Name = data.Name;
            model.DisplayName = data.DisplayName;

            return model;
        }

        public static IEnumerable<UnitOfMeasure> ConvertToListData(this IEnumerable<UnitOfMeasureModel> listData)
        {
            return listData.Select(model => ConvertToData(model)).ToList();
        }
        #endregion
    }
}