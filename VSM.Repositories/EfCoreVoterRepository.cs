using Nest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VSM.LoggerService.Contracts;
using VSM.Model;
using VSM.Repositories.DataBaseRepo;

namespace VSM.Repositories
{
    public class EfCoreVoterRepository
    {
        private readonly ILoggerManager _logger;
        private readonly EfDbOperationsRepository _dbOperations;
        private readonly ElasticClient _client;
        public EfCoreVoterRepository(ILoggerManager logger, EfDbOperationsRepository dbOperations)
        {
            _logger = logger;
            _dbOperations = dbOperations;
        }
        /// <summary> 
        /// Get all voters 
        /// </summary>
        /// <returns>all Voters in json</returns>
        public async Task<AddVoterViewModel> GetVoters()
        {
            ISearchResponse<AddVoterViewModel> results;
            results = await _client.SearchAsync<AddVoterViewModel>(s => s
            .Index("Voter")
       .Query(q => q
           .MatchAll()
       ));
          
            return (AddVoterViewModel)results;
            // return await _dbOperations.ExecuteDataSetAsync("spGetVoters");
        }
        /// <summary>
        /// Add/Update Voter Detail
        /// </summary>
        /// <param name="model"></param>
        /// <returns> -1: Vote < 18; 1 : Added successfully ; 0:Failed  </returns>
        public async Task<int> SaveVoter(AddVoterViewModel model)
        {
            if (model.Age < 18)
            {
                return -1;
            }
            else
            {
                List<SqlParameterModel> param = new List<SqlParameterModel>()
             {
               new SqlParameterModel(){ Name = "VoterName", Value = model.VoterName},
               new SqlParameterModel(){ Name = "Age", Value =model.Age}
             };
                var id = Convert.ToInt32(await _dbOperations.ExecuteDataSetAsync("spSaveVoter", param));
                model.VoterId = id;
                var res = await _client.IndexAsync<AddVoterViewModel>(model, x => x.Index("Voter"));
                return 1;
            }
        }
        public async Task<bool> DeleteVoter(int VoterId)
        {
            List<SqlParameterModel> param = new List<SqlParameterModel>()
             {
               new SqlParameterModel(){ Name = "VoterId", Value = VoterId},
             };
            var res = await _client.DeleteAsync<AddVoterViewModel>(VoterId, x => x.Index("Voter"));
            return true;
                //Convert.ToBoolean(await _dbOperations.ExecuteDataSetAsync("spDeleteVoter", param));

        }
        public async Task<bool> ChangeVoterAge(ChangeAgeViewModel model)
        {
            List<SqlParameterModel> param = new List<SqlParameterModel>()
             {
               new SqlParameterModel(){ Name = "VoterId", Value = model.VoterId},
               new SqlParameterModel(){ Name = "Age", Value = model.Age}
             };
            await _client.UpdateAsync<AddVoterViewModel>(model.VoterId, u => u.Index("Voter").Doc(new AddVoterViewModel { Age = model.Age }));

            return Convert.ToBoolean(await _dbOperations.ExecuteDataSetAsync("spChangeVoterAge", param));

        }
    }
}
