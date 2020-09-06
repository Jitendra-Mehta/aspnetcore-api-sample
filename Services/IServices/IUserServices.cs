using aspnetcore_api_sample.Models;
using aspnetcore_api_sample.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcore_api_sample.Services.IServices
{
    public interface IUserServices
    {
        bool AddNewUser(User user);
        bool UpdateNewUser(User user);
        List<ViewUsers> getUserList();
        User getUserById(int id);
        ValidatedUser ValidateUser(userAuthenticate user); 
    }
}
