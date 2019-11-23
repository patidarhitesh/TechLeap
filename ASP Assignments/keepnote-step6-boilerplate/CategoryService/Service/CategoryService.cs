using System;
using System.Collections.Generic;
using CategoryService.Models;
using CategoryService.Repository;
using CategoryService.Exceptions;
using MongoDB.Driver;
using System.Linq;

namespace CategoryService.Service
{
    public class CategoryService:ICategoryService
    {
        //define a private variable to represent repository

        private readonly ICategoryRepository categoryRepo;
        /*
        Use constructor Injection to inject all required dependencies.
            */
        public CategoryService(ICategoryRepository categoryRepository)
        {
            categoryRepo = categoryRepository;
        }

        /*
	    * This method should be used to save a new category.
	    */
        public Category CreateCategory(Category category)
        {
            Category category1 = categoryRepo.GetCategoryById(category.Id);

            if (category1 == null)
            {
                return categoryRepo.CreateCategory(category);
            }

            else
            {
                throw new CategoryNotCreatedException("This category already exists");
            }
        }

        /* This method should be used to delete an existing category. */
        public bool DeleteCategory(int categoryId)
        {
            Category category1 = categoryRepo.GetCategoryById(categoryId);
            if (category1 != null)
            {
                return categoryRepo.DeleteCategory(categoryId);
            }
            else
            {
                throw new CategoryNotFoundException($"This category id not found");
            }
        }

        /*
	     * This method should be used to get all category by userId.
	     */
        public List<Category> GetAllCategoriesByUserId(string userId)
        {
            return categoryRepo.GetAllCategoriesByUserId(userId);
        }

        /*
	     * This method should be used to get a category by categoryId.
	     */
        public Category GetCategoryById(int categoryId)
        {
            var category1 = categoryRepo.GetCategoryById(categoryId);

            if (category1 != null)
            {
                return category1;
            }
            else
            {
                throw new CategoryNotFoundException($"This category id not found");
            }
        }

        /*
	    * This method should be used to update a existing category.
	    */
        public bool UpdateCategory(int categoryId, Category category)
        {
            var category1 = categoryRepo.GetCategoryById(categoryId);

            if (category1 != null)
            {
                return categoryRepo.UpdateCategory(categoryId, category1);
            }
            else
            {
                throw new CategoryNotFoundException($"This category id not found");
            }
        }
    }
}
