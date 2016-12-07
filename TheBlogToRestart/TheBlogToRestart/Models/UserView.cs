using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheBlogToRestart.Models
{
    public class UserView
    {
        public ApplicationUser User { get; set; }
        public List<ApplicationUser> Users { get; set; }
        public List<SelectListItem> Roles { get; set; }
        public List<Microsoft.AspNet.Identity.EntityFramework.IdentityRole> CurrentRole { get; set; }
        public string RoleId { get; set; }
        public string UserId { get; set; }
        public string Role { get; set; }

        public UserView()
        {
            Roles = new List<SelectListItem>();
            CurrentRole = new List<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>();
        }

        public void SetRuleNames(List<Microsoft.AspNet.Identity.EntityFramework.IdentityRole> roles)
        {
            foreach (var role in roles)
            {
                Roles.Add(new SelectListItem()
                {
                    Text = role.Name,
                    Value = role.Id
                });
            }
        }

        //not currently being used, meant for matching role name to ID
        public void SetCurrentRole(List<Microsoft.AspNet.Identity.EntityFramework.IdentityRole> roles)
        {
            foreach (var role in roles)
            {
                CurrentRole.Add(role);
            }
        }
    }
}