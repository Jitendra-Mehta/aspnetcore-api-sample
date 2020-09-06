using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aspnetcore_api_sample.Helpers;
using aspnetcore_api_sample.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace aspnetcore_api_sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InsertData();
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        private static void InsertData()
        {
            using (var context = new DbContextModel())
            {
                // Creates the database if not exists
                 context.Database.EnsureCreated();
                //run seed data
                if (context.Roles.Count()==0)
                {
                    PasswordHashingHelper hasspassword = new PasswordHashingHelper();

                    // Adds a role
                    var roles = new Role
                    {
                        id = 1,
                        roleName = "Admin"
                    };
                    context.Roles.Add(roles);
                    // Adds a role
                    var roles1 = new Role
                    {
                        id = 2,
                        roleName = "Admin2"
                    };
                    context.Roles.Add(roles1);
                    context.SaveChanges();

                    var user = new User()
                    {
                        name = "Jitendra Mehta",
                        email = "jitendra@gmail.com",
                        password = hasspassword.onewayHashing("admin" , "jitendra@gmail.com"),
                        created_at = DateTime.Now,
                        created_by = 1
                    };
                    user.users_has_roless.Add(new users_has_roles()
                    {
                        RoleId = 1,
                        roleName = "Admin"
                    });
                    user.users_has_roless.Add(new users_has_roles()
                    {
                        RoleId = 2,
                        roleName = "Admin2"
                    });
                    context.Users.Add(user);
                    // Saves changes
                    context.SaveChanges();


                    PrintData();
                }

            }
        }

        private static void PrintData()
        {
            // Gets and prints all roles in database
            using (var context = new DbContextModel())
            {
                var Roles = context.Roles.ToList();
                foreach (var item in Roles)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"id: {item.id}");
                    data.AppendLine($"role: {item.roleName}");
                    Console.WriteLine(data.ToString());
                }
            }
        }
    }
}
