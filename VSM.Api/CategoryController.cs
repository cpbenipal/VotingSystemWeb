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
    public class CategoryController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly EfCoreCategoryRepository _repository;
        public CategoryController(EfCoreCategoryRepository repository, ILoggerManager _logger)
        {
            _repository = repository;
            this._logger = _logger;
        }
        [HttpGet("GetCategories")]
        public async Task<IActionResult> Get(int GetCategoryId)
        {
            try
            {
                var result = await _repository.GetCategories(GetCategoryId);
                _logger.LogInfo("GetCategories");
                return Content(result, contentType: "application/json");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return NotFound();
            }
        }
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(AddCategoryViewModel model)
        {
            try
            {
                var result = await _repository.AddCategory(model);
                _logger.LogInfo("AddCategory");
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
