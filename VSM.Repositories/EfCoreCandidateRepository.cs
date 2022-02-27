using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VSM.LoggerService.Contracts;
using VSM.Model;
using VSM.Repositories.DataBaseRepo;

namespace VSM.Repositories
{
    public class EfCoreCandidateRepository
    {
        private readonly ILoggerManager _logger;
        private readonly EfDbOperationsRepository _dbOperations;
        public EfCoreCandidateRepository(ILoggerManager logger, EfDbOperationsRepository dbOperations)
        {
            _logger = logger;
            _dbOperations = dbOperations;
        }
        /// <summary>
        /// Get all voters 
        /// </summary>
        /// <returns>all Voters in json</returns>
        public async Task<string> GetCandidates(int CandidateId = 0)
        {
            List<SqlParameterModel> param = new List<SqlParameterModel>()
             {
               new SqlParameterModel(){ Name = "CandidateId", Value = CandidateId}
             };
            return await _dbOperations.ExecuteDataSetAsync("spGetCandidates", param);
        }
        public async Task<string> CandidateVotes(int CandidateId) 
        {
            List<SqlParameterModel> param = new List<SqlParameterModel>()
             {
               new SqlParameterModel(){ Name = "CandidateId", Value = CandidateId}
             };
            return await _dbOperations.ExecuteDataSetAsync("spCandidateVotes", param);
        }
        /// <summary>
        /// Add/Update Voter Detail
        /// </summary>
        /// <param name="VoterName"></param>
        /// <param name="VoterId"></param>
        /// <param name="Age"></param>
        /// <returns></returns> 
        public async Task<bool> AddCandidate(CandidateViewModel model)
        {
            List<SqlParameterModel> param = new List<SqlParameterModel>()
             {
               new SqlParameterModel(){ Name = "CandidateName", Value = model.CandidateName}
             };
            return Convert.ToBoolean(await _dbOperations.ExecuteDataSetAsync("spAddCandidate", param));

        }
        public async Task<bool> VoteToCandidate(VoteViewModel model) 
        {
            List<SqlParameterModel> param = new List<SqlParameterModel>()
             {
                new SqlParameterModel(){ Name = "CandidateId", Value =model.CandidateId},
                new SqlParameterModel(){ Name = "VoterId", Value = model.VoterId}
             };
            return Convert.ToBoolean(await _dbOperations.ExecuteDataSetAsync("spVoteToCandidate", param));
        }
        public async Task<bool> AddCandidatetoCategory(AddCandidateViewModel model)
        {
            List<SqlParameterModel> param = new List<SqlParameterModel>()
             {
                new SqlParameterModel(){ Name = "CandidateId", Value = model.CandidateId},
                new SqlParameterModel(){ Name = "CategoryId", Value = model.CategoryId}
             };
            return Convert.ToBoolean(await _dbOperations.ExecuteDataSetAsync("spAddCandidatetoCategory", param));
        }

    }
}
