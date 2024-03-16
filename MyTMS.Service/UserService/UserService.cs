using Firebase.Auth;
using Mapster;
using MyTMS.Data.Entities;
using MyTMS.Data.Models.User;
using MyTMS.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using User = MyTMS.Data.Entities.User;

namespace MyTMS.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly FirebaseAuthClient _firebaseAuthClient;



        public UserService(

            IRepository<User> userRepository,
            FirebaseAuthClient firebaseAuthClient
            )
        {

            _userRepository = userRepository;
            _firebaseAuthClient = firebaseAuthClient;
        }

        public async Task<IQueryable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(long id)
        {
            var result = await _userRepository.GetByIdAsync(id);
            return result;
        }

        public async Task<string> UserLogin(string email, string password)
        {
            var result = await _firebaseAuthClient.SignInWithEmailAndPasswordAsync(email, password);
            if (result != null)
            {
                var token = await result.User.GetIdTokenAsync();
                return token;
            }
            throw new Exception("Authentication failed!");

        }

        public async Task<User> RegisterUser(AddUserInput input)
        {

            var userFireBaseRecord = await _firebaseAuthClient.CreateUserWithEmailAndPasswordAsync(input.Email, input.Password);
            if (userFireBaseRecord != null)
            {
                var userEntity = input.Adapt<User>();
                userEntity.AuthId = userFireBaseRecord.User.Uid;
                var result = await _userRepository.CreateAsync(userEntity);
                return result;
            }

            throw new Exception("Sorry, cannot create user!");



        }
    }
}
