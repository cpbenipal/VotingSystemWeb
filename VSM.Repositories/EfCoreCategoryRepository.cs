using Nest;
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
        private readonly ElasticClient _client;


        public EfCoreCategoryRepository(ILoggerManager logger, EfDbOperationsRepository dbOperations,ElasticClient client)
        {
            _logger = logger;
            _dbOperations = dbOperations;
            _client = client;
        }

        public async Task<AddCategoryViewModel> GetCategories(int CategoryId = 0)
        {
            List<SqlParameterModel> param = new List<SqlParameterModel>()
             {
              new SqlParameterModel(){ Name = "CategoryId", Value = CategoryId},
             };
            ISearchResponse<AddCategoryViewModel> results;
            results = await _client.SearchAsync<AddCategoryViewModel>(s => s
            .Index("Category")
       .Query(q => q
           .MatchAll()
       ));

            return (AddCategoryViewModel)results;

            //return await _dbOperations.ExecuteDataSetAsync("spGetCategories", param);
        }

        public async Task<bool> AddCategory(AddCategoryViewModel model)
        {
            List<SqlParameterModel> param = new List<SqlParameterModel>()
             {
               new SqlParameterModel(){ Name = "CategoryName", Value = model.CategoryName}
             };
            int id= Convert.ToInt32(await _dbOperations.ExecuteDataSetAsync("spAddCategory", param));
            model.CategoryId = id;
            var res = await _client.IndexAsync<AddCategoryViewModel>(model, x => x.Index("Category"));
            return true;

        }
    }
}
