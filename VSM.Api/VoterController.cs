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
    public class VoterController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        private readonly EfCoreVoterRepository _repository;
        public VoterController(EfCoreVoterRepository repository, ILoggerManager _logger)
        {
            _repository = repository;
            this._logger = _logger;
        }
        [HttpGet("GetVoters")]
        public async Task<IActionResult> GetVoters()
        {
            try
            {
                var result = await _repository.GetVoters();
                _logger.LogInfo("GetVoters");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return NotFound();
            }
        }
        [HttpPost("SaveVoter")]
        public async Task<IActionResult> SaveVoter(AddVoterViewModel model)
        {
            try
            {
                var result = await _repository.SaveVoter(model);
                _logger.LogInfo("GetVoters");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return NotFound();
            }
        }
        [HttpDelete("DeleteVoter")]
        public async Task<IActionResult> DeleteVoter(int VoterId)
        {
            try
            {
                var result = await _repository.DeleteVoter(VoterId);
                _logger.LogInfo("DeleteVoter");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return NotFound();
            }
        }
        [HttpPut("ChangeVoterAge")]
        public async Task<IActionResult> ChangeVoterAge(ChangeAgeViewModel model)
        {
            try
            {
                var result = await _repository.ChangeVoterAge(model);

                _logger.LogInfo("ChangeVoterAge");

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
