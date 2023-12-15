using Domain.Models;
using Getri_API_OnionArchitecture.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Repository;
using System.Net;

namespace Getri_API_OnionArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository iUserRepository;
        private readonly IUserProfileRepository iUserProfileRepository;

        public UserController(IUserRepository _iUserRepository, IUserProfileRepository _iUserProfileRepository)
        {
            iUserRepository = _iUserRepository;
            iUserProfileRepository = _iUserProfileRepository;
        }

        [HttpPost("CreateUsers")]
        public int CreateUser(CreateUserDTO model)
        {
           /* User userEntity = new User();
            userEntity.UserName = model.UserName;
            userEntity.Password = model.Password;
            userEntity.Email = model.Email;
            userEntity.ModifiedDate = DateTime.UtcNow;
            userEntity.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            userEntity.Profile = new UserProfile();
            userEntity.Profile.FirstName = model.Firstname;
            userEntity.Profile.LastName = model.Lastname;
            userEntity.Profile.Address = model.Address;
            userEntity.Profile.ContactNo = model.ContactNo;
            userEntity.Profile.ModifiedDate = DateTime.UtcNow;
            userEntity.Profile.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
           */

            User userEntity = new User
            {
                UserName = model.UserName,
                Password = model.Password,
                Email = model.Email,
                ModifiedDate = DateTime.UtcNow,
                IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                Profile = new UserProfile
                {
                    FirstName = model.Firstname,
                    LastName = model.Lastname,
                    Address = model.Address,
                    ContactNo = model.ContactNo,
                    ModifiedDate = DateTime.UtcNow,
                    IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString()
                }
            };

            iUserRepository.InsertUser(userEntity);
            return 1;
        }

        [HttpPut("UpdateUser")]
        public int UpdateUser(UpdateUserDTO model)
        {
            User userEntity = new User();
            userEntity.Id = model.Id;
            userEntity.UserName = model.UserName;
            userEntity.Password = model.Password;
            userEntity.Email = model.Email;
            userEntity.ModifiedDate = DateTime.UtcNow;
            userEntity.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            userEntity.Profile = new UserProfile();
            userEntity.Profile.Id = model.Id;
            userEntity.Profile.FirstName = model.Firstname;
            userEntity.Profile.LastName = model.Lastname;
            userEntity.Profile.Address = model.Address;
            userEntity.Profile.ContactNo = model.ContactNo;
            userEntity.Profile.ModifiedDate = DateTime.UtcNow;
            userEntity.Profile.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();

            iUserRepository.UpdateUser(userEntity);
            return 1;
        }

        [HttpDelete("DeleteUser")]
        public int DeleteUser(Int64 Id)
        {
            iUserRepository.DeleteUser(Id);
            return 1;
        }

        [HttpGet("GetUserById")]
        public IActionResult GetUserById(Int64 Id)
        {
            User user = new User();
            user = iUserRepository.Getuser(Id);
            UserProfile userProfile = iUserProfileRepository.GetUserProfile(Id);           
            user.Profile = new UserProfile();
            user.Profile.Id = userProfile.Id;
            user.Profile.FirstName = userProfile.FirstName;
            user.Profile.LastName = userProfile.LastName;
            user.Profile.Address = userProfile.Address;
            user.Profile.ContactNo = userProfile.ContactNo;
            user.Profile.ModifiedDate = userProfile.ModifiedDate;
            user.Profile.IPAddress = userProfile.IPAddress;
            return Ok(user);
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            List<User> lstUser = new List<User>();
            var lstUsers = iUserRepository.GetUsers().ToList();

            foreach (var item in lstUsers)
            {
                User user = new User();
                UserProfile userProfile = iUserProfileRepository.GetUserProfile(item.Id);
                user.Id = item.Id;
                user.UserName = item.UserName;
                user.Password = item.Password;
                user.Email = item.Email;
                user.ModifiedDate = item.ModifiedDate;
                user.IPAddress = item.IPAddress;
                user.Profile = new UserProfile();
                user.Profile.Id = userProfile.Id;
                user.Profile.FirstName = userProfile.FirstName;
                user.Profile.LastName = userProfile.LastName;
                user.Profile.Address = userProfile.Address;
                user.Profile.ContactNo = userProfile.ContactNo;
                user.Profile.ModifiedDate = userProfile.ModifiedDate;
                user.Profile.IPAddress = userProfile.IPAddress;
                lstUser.Add(user);
            }

            return Ok(lstUser);
        }
    }    
}
