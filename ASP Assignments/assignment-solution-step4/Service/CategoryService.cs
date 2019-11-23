using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Entities;
using Exceptions;

namespace Service
{
    /*
    * Service classes are used here to implement additional business logic/validation
    * */
    public class CategoryService : ICategoryService
    {
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
            return categoryRepo.CreateCategory(category);
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
                throw new CategoryNotFoundException($"Category with id: {categoryId} does not exist");
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
                throw new CategoryNotFoundException($"Category with id: {categoryId} does not exist");
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
                return categoryRepo.UpdateCategory(category1);
            }
            else
            {
                throw new CategoryNotFoundException($"Category with id: {categoryId} does not exist");
            }
        }
    }
}
