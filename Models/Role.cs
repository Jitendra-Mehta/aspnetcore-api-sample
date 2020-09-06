using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcore_api_sample.Models
{
    public class Role
    {
      
        [Key , DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required(ErrorMessage = "Role is required.")]
        public string roleName{ get; set; }
        // many to many relationship
        public IList<users_has_roles> users_has_roless { get; set; }
    }
}
