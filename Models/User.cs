using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace aspnetcore_api_sample.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string name{ get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string email{ get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [JsonIgnore]
        public string password{ get; set; }
        public string Address { get; set; }
        public string mobile { get; set; }
        public DateTime created_at { get; set; }
        public int created_by { get; set; }
        public DateTime updated_at { get; set; }
        public int updated_by { get; set; } 
        // many to many relationship
        public IList<users_has_roles> users_has_roless { get; set; }

        public User()
        {
            users_has_roless = new List<users_has_roles>();
        }

    }
}
