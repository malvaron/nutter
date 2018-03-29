using Microsoft.AspNetCore.Mvc;
using nutter.api.Models;
using System.Collections.Generic;
using System.Linq;

namespace nutter.api.Controllers
{
    [Route("api/[controller]")]
    public class FoodItemsController : Controller
    {
        private readonly FoodItemContext _context;

        public FoodItemsController(FoodItemContext context)
        {
            _context = context;

            if (!_context.FoodItem.Any())
            {
                var exampleItem = new FoodItem { Name = "Palak paneer", Protein = 29.5M, Fat = 67M, Carbohydrates = 64M, Calories = 987M };
                _context.FoodItem.Add(exampleItem);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<FoodItem> GetAll()
        {
            return _context.FoodItem.ToList();
        }

        [HttpGet("{id}", Name = "GetFoodItem")]
        public IActionResult GetById(long id)
        {
            var item = _context.FoodItem.FirstOrDefault(f => f.Id == id);
            if (item == null)
                return NotFound();

            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] FoodItem item)
        {
            if (item == null)
                return BadRequest();

            _context.FoodItem.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetFoodItem", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] FoodItem item)
        {
            if (item == null || item.Id != id)
                return BadRequest();

            var foodItem = _context.FoodItem.FirstOrDefault(f => f.Id == id);
            if (foodItem == null)
                return NotFound();

            foodItem.Name = item.Name;
            foodItem.Protein = item.Protein;
            foodItem.Fat = item.Fat;
            foodItem.Carbohydrates = item.Carbohydrates;
            foodItem.Calories = item.Calories;

            _context.FoodItem.Update(foodItem);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var foodItem = _context.FoodItem.FirstOrDefault(f => f.Id == id);
            if (foodItem == null)
                return NotFound();

            _context.FoodItem.Remove(foodItem);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
