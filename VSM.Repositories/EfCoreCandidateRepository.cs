using Nest;
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
        private readonly ElasticClient _client;
        public EfCoreCandidateRepository(ILoggerManager logger, EfDbOperationsRepository dbOperations, ElasticClient client)
        {
            _logger = logger;
            _dbOperations = dbOperations;
            _client = client;
        }
        /// <summary>
        /// Get all voters 
        /// </summary>
        /// <returns>all Voters in json</returns>
        public async Task<CandidateViewModel> GetCandidates(int CandidateId = 0)
        {
            //List<SqlParameterModel> param = new List<SqlParameterModel>()
            // {
            //   new SqlParameterModel(){ Name = "CandidateId", Value = CandidateId}
            // };
            ISearchResponse<CandidateViewModel> results;
            results = await _client.SearchAsync<CandidateViewModel>(s => s
            .Index("Category")
       .Query(q => q
           .MatchAll()
       ));

            return (CandidateViewModel)results;
            // return await _dbOperations.ExecuteDataSetAsync("spGetCandidates", param);
        }
        public async Task<CandidateViewModel> CandidateVotes(int CandidateId)
        {
            //List<SqlParameterModel> param = new List<SqlParameterModel>()
            // {
            //   new SqlParameterModel(){ Name = "CandidateId", Value = CandidateId}
            // };
            ISearchResponse<CandidateViewModel> results;
            results = await _client.SearchAsync<CandidateViewModel>(s => s
            .Index("Candidate")
        .Query(q => q.Term(t => t.Field("CandidateId").Value(CandidateId))
       ));

            return (CandidateViewModel)results;
            // return await _dbOperations.ExecuteDataSetAsync("spCandidateVotes", param);
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
            var id = Convert.ToInt32(await _dbOperations.ExecuteDataSetAsync("spAddCandidate", param));
            model.CandidateId = id;
            var res = await _client.IndexAsync<CandidateViewModel>(model, x => x.Index("Candidate"));
            return true;

        }
        public async Task<bool> VoteToCandidate(VoteViewModel model)
        {
            List<SqlParameterModel> param = new List<SqlParameterModel>()
             {
                new SqlParameterModel(){ Name = "CandidateId", Value =model.CandidateId},
                new SqlParameterModel(){ Name = "VoterId", Value = model.VoterId}
             };
            var id=Convert.ToInt32(await _dbOperations.ExecuteDataSetAsync("spVoteToCandidate", param));
            model.VoteId = id;
            var res = await _client.IndexAsync<VoteViewModel>(model, x => x.Index("Vote"));

            return true;
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
