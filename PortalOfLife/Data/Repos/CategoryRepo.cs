using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtalOfLife.Models.Data;

namespace Data.Repos
{
    public class CategoryRepo : ICategoryRepository
    {
        private static List<Category> _categories;
        static CategoryRepo()
        {
            _categories = new List<Category>
            {
                new Category {
                    Name = "Code of Conduct",
                    Id = 1,
                    Policies = new List<Policy>
                    {
                        new Policy {Name = "Dress Code", CategoryId = 1, Content = "This is the content for Dress code!" },
                        new Policy {Name = "Workplace Expectations", CategoryId = 1, Content = "This is the content for Workplace Expectations!" }
                    }
                },
                new Category {
                    Name = "Benefits",
                    Id = 2,
                    Policies = new List<Policy>
                    {
                        new Policy {Name = "Healthcare", CategoryId = 2, Content = "This is the content for Healthcare!" },
                        new Policy {Name = "Retirement", CategoryId = 2, Content = "This is the content for Retirement!" }
                    }
                },
                new Category {
                    Name = "New Hire",
                    Id = 3,
                    Policies = new List<Policy>
                    {
                        new Policy {Name = "Job Offer", CategoryId = 3, Content = "This is the content for Job offer!" },
                        new Policy {Name = "Training", CategoryId = 3, Content = "This is the content for Training!" }
                    }
                },
                new Category {
                    Name = "Payroll",
                    Id = 4,
                    Policies = new List<Policy>
                    {
                        new Policy {Name = "Hourly Pay", CategoryId = 4, Content = "This is the content for Hourly pay!"},
                        new Policy {Name = "Vacation Pay",CategoryId = 4, Content = "This is the content for Vacation Pay!" }
                    }
                }
            };
        }
        public bool AddCategory(Category category)
        {
            if (!_categories.Any(c => c.Name == category.Name))
            {
                var categoryId = _categories.Count;
                category.Id = categoryId + 1;
                _categories.Add(category);
                return true;
            }
            return false;
        }

        public bool AddPolicy(Policy policy)
        {
            foreach (var category in _categories)
            {
                foreach (var item in category.Policies)
                {
                    if (item.CategoryId == category.Id)
                    {
                        category.Policies.Add(policy);
                        return true;
                    }
                }
            }
            return false;
            //_categories.FirstOrDefault(c => c.Id == policy.CategoryId).Policies.Add(policy);
        }

        public Category Get(string name)
        {
            return _categories.FirstOrDefault(c => c.Name == name);
        }

        public IEnumerable<Category> GetAll()
        {
            return _categories;
        }

        public bool RemovePolicy(Policy policy)
        {
            foreach (var category in _categories)
            {
                foreach (var oldPolicy in category.Policies)
                {
                    if (oldPolicy.Name == policy.Name)
                    {
                        category.Policies.Remove(oldPolicy);
                        return true;
                    }
                }
            }
            return false;
        }

        public Policy GetPolicy(Policy policy)
        {
            foreach (var category in _categories)
            {
                foreach (var oldPolicy in category.Policies)
                {
                    if (oldPolicy.Name == policy.Name)
                    {
                        oldPolicy.isValid = true;
                        return oldPolicy;
                    }
                }
            }
            policy.isValid = false;
            return policy;
        }

        public bool DeleteCategory(string name)
        {
            if (_categories.Any(c => c.Name == name))
            {
                _categories.RemoveAll(p => p.Name == name);
                return true;
            }
            return false;
            //_categories.RemoveAll(c => c.Name == name);
        }
    }
}
