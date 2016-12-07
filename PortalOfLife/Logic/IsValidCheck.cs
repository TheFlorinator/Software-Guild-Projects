using ProtalOfLife.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class IsValidCheck
    {
        public static Category IsValidCategory(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
            {
                category.isValid = false;
            }
            else
            {
                category.isValid = true;
            }
            return category;
        }
        public static Policy IsValidPolicyLookup(Policy policy)
        {
            if (string.IsNullOrWhiteSpace(policy.Name))
            {
                policy.isValid = false;
            }
            else
            {
                policy.isValid = true;
            }
            return policy;
        }
        public static Policy IsValidPolicy(Policy policy)
        {
            if (string.IsNullOrWhiteSpace(policy.Name))
            {
                policy.isValid = false;
            }
            else if (string.IsNullOrWhiteSpace(policy.Content))
            {
                policy.isValid = false;
            }
            else
            {
                policy.isValid = true;
            }
            return policy;
        }
    }
}
