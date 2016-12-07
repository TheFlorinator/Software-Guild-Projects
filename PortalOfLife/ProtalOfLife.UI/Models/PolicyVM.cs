using ProtalOfLife.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProtalOfLife.UI.Models
{
    public class PolicyVM
    {
        public List<SelectListItem> policyItems { get; set; }
        public Category categoryItems { get; set; }

        public PolicyVM()
        {
            policyItems = new List<SelectListItem>();
            categoryItems = new Category();

        }

        public void SetPolicies(IEnumerable<Policy> policies)
        {
            foreach (var policy in policies)
            {
                policyItems.Add(new SelectListItem()
                {
                    Value = policy.CategoryId.ToString(),
                    Text = policy.Name
                });
            }
        }
    }
}