using Models.Interfaces;
using ProtalOfLife.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProtalOfLife.Data.Repos
{
    public class PolicyRepo : IPolicyRepository
    {
        private static List<Policy> _policies;

        static PolicyRepo()
        {
            _policies = new List<Policy>
            {
                new Policy {Name = "Dress Code", CategoryId = 1, Content = "This is the content for Dress code!" },
                new Policy {Name = "Workplace Expectations", CategoryId = 1, Content = "This is the content for Workplace Expectations!" },
                new Policy {Name = "Healthcare", CategoryId = 2, Content = "This is the content for Healthcare!" },
                new Policy {Name = "Retirement", CategoryId = 2, Content = "This is the content for Retirement!" },
                new Policy {Name = "Job Offer", CategoryId = 3, Content = "This is the content for Job offer!" },
                new Policy {Name = "Training", CategoryId = 3, Content = "This is the content for Training!" },
                new Policy {Name = "Hourly Pay", CategoryId = 4, Content = "This is the content for Hourly pay!"},
                new Policy {Name = "Vacation Pay",CategoryId = 4, Content = "This is the content for Vacation Pay!" }
            };
        }

        public IEnumerable<Policy> GetAll()
        {
            return _policies;
        }

        public Policy Get(Policy policy)
        {
            return _policies.FirstOrDefault(p => p.Name == policy.Name);
        }

        public void Add(Policy policy)
        {
            _policies.Add(policy);
        }

        public void Delete(int policyId)
        {
            _policies.RemoveAll(p => p.CategoryId == policyId);
        }

        public void Edit(Policy policy)
        {
            var chosenPolicy = _policies.FirstOrDefault(p => p.CategoryId == policy.CategoryId);
            chosenPolicy.Name = policy.Name;
            chosenPolicy.Content = policy.Content;
        }

    }
}