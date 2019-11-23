using System;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace DAL
{
    //Repository class is used to implement all Data access operations
    public class CategoryRepository : ICategoryRepository
    {
        private readonly KeepDbContext context;
        public CategoryRepository(KeepDbContext dbContext)
        {
            context = dbContext;
        }
        /*
	    * This method should be used to save a new category.
	    */
        public Category CreateCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return category;
        }
        /* This method should be used to delete an existing category. */
        public bool DeleteCategory(int categoryId)
        {
            Category cat = context.Categories.Find(categoryId);
            context.Categories.Remove(cat);
            if (context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        //* This method should be used to get all category by userId.
        public List<Category> GetAllCategoriesByUserId(string userId)
        {
            List<Category> cat = context.Categories.Where(c => c.CategoryCreatedBy == userId).ToList();
            return cat;
        }

        /*
	     * This method should be used to get a category by categoryId.
	     */
        public Category GetCategoryById(int categoryId)
        {
            return context.Categories.Find(categoryId);
        }

        /*
	    * This method should be used to update a existing category.
	    */
        public bool UpdateCategory(Category category)
        {
            context.Entry<Category>(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return true;
        }
    }
}
