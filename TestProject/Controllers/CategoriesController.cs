using Microsoft.AspNetCore.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();
            return View(categories);
        }
        
        public IActionResult Edit(int? id)
        { 
            var category = CategoriesRepository.GetCategoryById(id.HasValue?id.Value:0);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction(nameof(Index));

            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Category()); // Pass an empty Category object to the view
        }

        [HttpPost]
        public IActionResult Add([FromForm] Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index)); // Redirect to Index on success
            }

            // Validation failed, display error messages and re-render the view
            return View(category); // Return the same view with the category object and errors
        }
        public IActionResult Delete(int categoryId)
        {
            CategoriesRepository.DeleteCategory(categoryId);
            return RedirectToAction(nameof(Index));
        }
     
    }
}