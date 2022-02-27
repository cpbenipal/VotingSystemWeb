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
        public EfCoreVoterRepository(ILoggerManager logger, EfDbOperationsRepository dbOperations)
        {
            _logger = logger;
            _dbOperations = dbOperations;
        }
        /// <summary> 
        /// Get all voters 
        /// </summary>
        /// <returns>all Voters in json</returns>
        public async Task<string> GetVoters()
        {
            return await _dbOperations.ExecuteDataSetAsync("spGetVoters");
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
                return Convert.ToBoolean(await _dbOperations.ExecuteDataSetAsync("spSaveVoter", param)) ? 1 : 0;                
            }
        }
        public async Task<bool> DeleteVoter(int VoterId)
        {
            List<SqlParameterModel> param = new List<SqlParameterModel>()
             {
               new SqlParameterModel(){ Name = "VoterId", Value = VoterId},
             };
            return Convert.ToBoolean(await _dbOperations.ExecuteDataSetAsync("spDeleteVoter", param));

        }
        public async Task<bool> ChangeVoterAge(ChangeAgeViewModel model)
        {
            List<SqlParameterModel> param = new List<SqlParameterModel>()
             {
               new SqlParameterModel(){ Name = "VoterId", Value = model.VoterId},
               new SqlParameterModel(){ Name = "Age", Value = model.Age}
             };
            return Convert.ToBoolean(await _dbOperations.ExecuteDataSetAsync("spChangeVoterAge", param));

        }
    }
}
