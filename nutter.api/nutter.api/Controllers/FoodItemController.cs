using Microsoft.AspNetCore.Mvc;
using nutter.api.Models;
using System.Collections.Generic;
using System.Linq;

namespace nutter.api.Controllers
{
    [Route("api/[controller]")]
    public class FoodItemController : Controller
    {
        private readonly FoodItemContext _context;

        public FoodItemController(FoodItemContext context)
        {
            _context = context;

            if (_context.FoodItems.Count() == 0)
            {
                var exampleItem = new FoodItem { Name = "Palak paneer", Protein = 29.5M, Fat = 67M, Carbohydrates = 64M, Calories = 987M };
                _context.FoodItems.Add(exampleItem);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<FoodItem> GetAll()
        {
            return _context.FoodItems.ToList();
        }

        [HttpGet("{id}", Name = "GetFoodItem")]
        public IActionResult GetById(long id)
        {
            var item = _context.FoodItems.FirstOrDefault(f => f.Id == id);
            if (item == null)
                return NotFound();

            return new ObjectResult(item);
        }
    }
}
