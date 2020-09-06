using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcore_api_sample.Models.ViewModels
{
    public class View_users_has_roles
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string roleName { get; set; }
    }
}
