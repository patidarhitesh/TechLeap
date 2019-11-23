using System;
using System.Collections.Generic;
using System.Linq;
using CategoryService.Models;
using MongoDB.Driver;

namespace CategoryService.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
      

       
            //define a private variable to represent CategoryContext
            private readonly CategoryContext context;
            public CategoryRepository(CategoryContext _context)
            {
                context = _context;
            }

            //This method should be used to save a new category.
            public Category CreateCategory(Category category)
            {
                var list = context.Categories.Find(_ => true).ToList();
                if (list.Count == 0)
                {
                    category.Id = 101;
                }
                else
                {
                    category.Id = list.Count + 101;
                }
                context.Categories.InsertOne(category);
                return category;
            }

            //This method should be used to delete an existing category.
            public bool DeleteCategory(int categoryId)
            {
                var deleteResult = context.Categories.DeleteOne(c => c.Id == categoryId);
                return deleteResult.DeletedCount > 0;
            }

            //This method should be used to get all category by userId
            public List<Category> GetAllCategoriesByUserId(string userId)
            {
                return context.Categories.Find(c => c.CreatedBy == userId).ToList();
            }

            //This method should be used to get a category by categoryId
            public Category GetCategoryById(int categoryId)
            {
                return context.Categories.Find(c => c.Id == categoryId).FirstOrDefault();
            }

            // This method should be used to update an existing category.
            public bool UpdateCategory(int categoryId, Category category)
            {
                var filter = Builders<Category>.Filter.Where(c => c.Id == categoryId);

                var updateResult = context.Categories.ReplaceOne(filter, category);
                return updateResult.MatchedCount > 0;
            }
        }
}
