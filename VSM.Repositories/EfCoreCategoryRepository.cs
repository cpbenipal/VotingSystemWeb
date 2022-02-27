using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VSM.LoggerService.Contracts;
using VSM.Model;
using VSM.Repositories.DataBaseRepo;

namespace VSM.Repositories
{
    public class EfCoreCategoryRepository
    {
        private readonly ILoggerManager _logger;
        private readonly EfDbOperationsRepository _dbOperations;

        public EfCoreCategoryRepository(ILoggerManager logger, EfDbOperationsRepository dbOperations)
        {
            _logger = logger;
            _dbOperations = dbOperations;
        }

        public async Task<string> GetCategories(int CategoryId = 0)  
        {
            List<SqlParameterModel> param = new List<SqlParameterModel>()
             {
              new SqlParameterModel(){ Name = "CategoryId", Value = CategoryId},
             };

            return await _dbOperations.ExecuteDataSetAsync("spGetCategories", param);
        }
        
        public async Task<bool> AddCategory(AddCategoryViewModel model)
        {              
            List<SqlParameterModel> param = new List<SqlParameterModel>()
             {
               new SqlParameterModel(){ Name = "CategoryName", Value = model.CategoryName}  
             };
            return Convert.ToBoolean(await _dbOperations.ExecuteDataSetAsync("spAddCategory", param));

        }
    }
}
