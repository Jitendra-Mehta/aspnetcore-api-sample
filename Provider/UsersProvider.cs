using aspnetcore_api_sample.Helpers;
using aspnetcore_api_sample.Models;
using aspnetcore_api_sample.Models.ViewModels;
using aspnetcore_api_sample.Provider.IProvider;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcore_api_sample.Provider
{
    public class UsersProvider : IUsersProvider
    {
        private IConfiguration config;
        public bool AddNewUser(User user)
        {
            user.password = hasspassword.onewayHashing(user.password, user.email);
            _dbContext.Users.AddRange(user);
            _dbContext.SaveChanges();
            return true;
        }

        public User getUserById(int id)
        {

            return _dbContext.Users.Include(x => x.users_has_roless).FirstOrDefault(x => x.id == id);
        }

        public List<User> getUserList()
        {
            return _dbContext.Users.Include(x => x.users_has_roless).ToList();
        }

        public bool UpdateNewUser(User user)
        {
            _dbContext.Users.UpdateRange(user);
            _dbContext.SaveChanges();
            return true;
        }

        public ValidatedUser ValidateUser(string username, string password)
        {
            password = hasspassword.onewayHashing(password, username);

            TokenHelpers token_helper = new TokenHelpers();

            var user = _dbContext.Users.Include(x => x.users_has_roless).FirstOrDefault(x => x.email == username && x.password == password);
            if (user == null)
                return null;

            var token = token_helper.CreateToken(user, _config["Jwt:Key"], _config["Jwt:Issuer"], _config["Jwt:Audience"]);
            var returndata = _mapper.Map<ValidatedUser>(user);
            returndata.token = token;
            return returndata;// _dbContext.Users.Include(x => x.users_has_roless).FirstOrDefault(x => x.email == username && x.password == password);
        }


        private readonly DbContextModel _dbContext;
        private readonly PasswordHashingHelper hasspassword;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public UsersProvider(IMapper mapper, IConfiguration config)
        {
            _config = config;
            _mapper = mapper;
            _dbContext = new DbContextModel();
            hasspassword = new PasswordHashingHelper();
        }
    }
}
