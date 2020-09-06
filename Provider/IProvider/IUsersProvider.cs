using aspnetcore_api_sample.Models;
using aspnetcore_api_sample.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcore_api_sample.Provider.IProvider
{
    public interface IUsersProvider
    {
        bool AddNewUser(User user);
        bool UpdateNewUser(User user);
        List<User> getUserList();
        User getUserById(int id);
        ValidatedUser ValidateUser(string username , string password); 
    }
}
