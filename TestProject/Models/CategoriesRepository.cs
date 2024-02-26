using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace TestProject.Models
{
    public class CategoriesRepository
    {
        public static List<Category> _categories = new List<Category>()
        {
           new Category{CategoryId=1, Name="Shart",Description="Shart"},
           new Category{CategoryId=2, Name="Show",Description="Show"},
           new Category{CategoryId=3, Name="Pant",Description="Pant"}
         };
        

        //create 
        public static void AddCategory(Category category)
        {
            var maxId = _categories.Max(x => x.CategoryId);
            category.CategoryId = maxId + 1;
            _categories.Add(category);
        }
        public static List<Category> GetCategories() => _categories;
        //read
        public static Category? GetCategoryById(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (category != null)
            {
                return new Category
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description,

                };
            }

            return null;
        }

        //update
        public static void UpdateCategory(int categoryId, Category category)
        {
            if (categoryId != category.CategoryId) return;
            var categoryToUpdate = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }


        }

        //Delate
        public static void DeleteCategory(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }

        internal static void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}

