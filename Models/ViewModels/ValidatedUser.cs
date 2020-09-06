using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcore_api_sample.Models.ViewModels
{
    public class ValidatedUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string Address { get; set; }
        public string mobile { get; set; }       
        public IList<View_users_has_roles> users_has_roless { get; set; }
        public string token { get; set; }
        public ValidatedUser()
        {
            users_has_roless = new List<View_users_has_roles>();
        }
    } 
}
