using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VSM.LoggerService.Contracts;
using VSM.Model;
using VSM.Repositories;

namespace VSM.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly EfCoreCandidateRepository _repository;
        public CandidateController(EfCoreCandidateRepository repository, ILoggerManager logger)
        {
            _repository = repository; _logger = logger;
        }
        [HttpGet("GetCandidates")]
        public async Task<IActionResult> GetCandidates(int CandidateId)
        {
            try
            {
                var result = await _repository.GetCandidates(CandidateId);
                _logger.LogInfo("GetCandidates");

                return Content(result, contentType: "application/json");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return NotFound();
            }
        }
        [HttpGet("GetCandidateVotes")]
        public async Task<IActionResult> CandidateVotes(int CandidateId)
        {
            try
            {
                var result = await _repository.CandidateVotes(CandidateId);
                _logger.LogInfo("GetCandidateVotes");                

                return Content(result, contentType: "application/json");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return NotFound();
            }
        }
        [HttpPost("VoteToCandidate")]
        public async Task<IActionResult> VoteToCandidate(VoteViewModel model)
        {
            try
            {
                var result = await _repository.VoteToCandidate(model);
                _logger.LogInfo("VoteToCandidate");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                _logger.LogInfo("GetCategories");

                return NotFound();
            }
        }
        [HttpPost("AddCandidatetoCategory")]
        public async Task<IActionResult> AddCandidatetoCategory(AddCandidateViewModel model)
        {
            try
            {
                var result = await _repository.AddCandidatetoCategory(model);
                _logger.LogInfo("AddCandidatetoCategory");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return NotFound();
            }
        }
    }
}
