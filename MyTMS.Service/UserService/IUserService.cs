using MyTMS.Data.Models.User;
using MyTMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTMS.Service.UserService
{
    public interface IUserService
    {
        Task<IQueryable<User>> GetAllUsers();
        Task<User> RegisterUser(AddUserInput input);
        Task<string> UserLogin(string email, string password);
        Task<User> GetUserByIdAsync(long id);

    }
}
