using Models.Interfaces;
using ProtalOfLife.Models.Data;
using ProtalOfLife.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class PolicyGrinder
    {
        private ICategoryRepository _categoryRepository;
        private IApplicantRepository _applicationRepository;

        public PolicyGrinder(ICategoryRepository categoryRespository, IApplicantRepository applicationRepository)
        {
            _categoryRepository = categoryRespository;
            _applicationRepository = applicationRepository;
        }
        
        public IEnumerable<Category> GetAllCategoryies()
        {
            IEnumerable<Category> categories = new List<Category>();
            categories = _categoryRepository.GetAll();
            return categories;
        }

        public CategoryResponse GetOneCategory(string name)
        {
            CategoryResponse response = new CategoryResponse();
            response.NewCategory.Name = name;
            response.NewCategory = IsValidCheck.IsValidCategory(response.NewCategory);
            if (response.NewCategory.isValid == false)
            {
                response.Message = "An error has occurred";
                response.Success = false;
            }
            else
            {
                response.NewCategory = _categoryRepository.Get(name);
                response.Success = true;
            }

            return response;
        }

        public PolicyResponse GetOnePolicy(Policy policy)
        {
            PolicyResponse response = new PolicyResponse();
            response.NewPolicy = IsValidCheck.IsValidPolicyLookup(policy);
            if (response.NewPolicy.isValid == false)
            {
                response.Message = "An error occurred";
                response.Success = false;
            }
            else
            {
                response.NewPolicy = _categoryRepository.GetPolicy(policy);
                response.Success = true;
            }
            return response;
        }

        public PolicyResponse DeletePolicy(Policy policy)
        {
            PolicyResponse response = new PolicyResponse();
            response.NewPolicy = IsValidCheck.IsValidPolicyLookup(policy);
            if (response.NewPolicy.isValid == false)
            {
                response.Message = "An error has occurred";
                response.Success = false;
            }
            else if (!_categoryRepository.RemovePolicy(policy))
            {
                response.Message = "An error has occurred";
                response.Success = false;
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public PolicyResponse AddNewPolicy(Policy policy)
        {
            PolicyResponse response = new PolicyResponse();
            response.NewPolicy = IsValidCheck.IsValidPolicy(policy);
            if (response.NewPolicy.isValid == false)
            {
                response.Message = "Name and content must be provided";
                response.Success = false;
            }
            else if (!_categoryRepository.AddPolicy(policy))
            {
                response.Message = "An error has occurred";
                response.Success = false;
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public CategoryResponse AddNewCategory(Category category)
        {
            CategoryResponse response = new CategoryResponse();
            response.NewCategory = IsValidCheck.IsValidCategory(category);
            if (response.NewCategory.isValid == false)
            {
                response.Message = "A name must be provided";
                response.Success = false;
            }
            else if (!_categoryRepository.AddCategory(category))
            {
                response.Message = "An error has occurred";
                response.Success = false;
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public CategoryResponse DeleteCategory(string categoryName)
        {
            CategoryResponse response = new CategoryResponse();
            response.NewCategory.Name = categoryName;
            response.NewCategory = IsValidCheck.IsValidCategory(response.NewCategory);
            if (response.NewCategory.isValid == false)
            {
                response.Message = "An error has occurred";
                response.Success = false;
            }
            else if (!_categoryRepository.DeleteCategory(categoryName))
            {
                response.Message = "An error has occurred";
                response.Success = false;
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public void AddApplicant(Applicant applicant)
        {
            Applicant appliee = new Applicant();
            appliee = applicant;
            _applicationRepository.AddApplicant(appliee);
        }
    }
}
