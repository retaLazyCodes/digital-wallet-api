using DigitalWalletApi.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWalletApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _categoryService.GetAll();
            return Ok(categories);
        }
        
        [HttpPost]
        public IActionResult Create(string description)
        {
            var result = _categoryService.Add(description);
            if (result) {
                return Ok(new { Message = "Category Created Successful"});
            }
            else {
                return BadRequest();
            }
        }
        
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _categoryService.Delete(id);
            if (result) {
                return Ok(new { Message = "Deleted Successful"});
            }
            else {
                return BadRequest(new { Message = "The category with that id does not exist "});
            }
        }

    }
}