using aspnetcore_api_sample.Models;
using aspnetcore_api_sample.Models.ViewModels;
using aspnetcore_api_sample.Provider.IProvider;
using aspnetcore_api_sample.Services.IServices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcore_api_sample.Services
{
    public class UsersServices : IUserServices
    {
        public bool AddNewUser(User user)
        {
            return _IUsersProvider.AddNewUser(user);
        }

        public User getUserById(int id)
        {
            return _IUsersProvider.getUserById(id);
        }

        public List<ViewUsers> getUserList()
        {
            var data = _IUsersProvider.getUserList();
            var userlist =new  List<ViewUsers>();
            foreach (var item in data)
            {
                userlist.Add(_mapper.Map<ViewUsers>(item));
            }
            return userlist;
        }

        public bool UpdateNewUser(User user)
        {
            return _IUsersProvider.UpdateNewUser(user);
        }

        public ValidatedUser ValidateUser(userAuthenticate user)
        {
            return _IUsersProvider.ValidateUser(user.userName, user.password);
        }
      
        private IUsersProvider _IUsersProvider;
        private readonly IMapper _mapper;
        public UsersServices(IUsersProvider IUsersProvider, IMapper mapper)
        {
            _IUsersProvider = IUsersProvider;
            _mapper = mapper;
        }
    }
}
