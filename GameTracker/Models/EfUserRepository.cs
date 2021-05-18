using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace GameTracker.Models
{
    public class EfUserRepository : IUserRepository
    {
        private AppDbContext _context;
        private ISession     _session;
        public EfUserRepository(AppDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _session = httpContext.HttpContext.Session;
        }

        //Methods

        //Create

        public User Create(User u)
        {
            string encryptedPassword = EncryptPassword(u.Password);
            u.Password = encryptedPassword;

            User existingUser = GetUserByEmailAddress(u.Email);
            if (existingUser != null)
            {
                return null;
            }

            try
            {
                _context.User.Add(u);
                _context.SaveChanges();
                return u;
            }
            catch (Exception e)
            {
            }

            return null;
        }
        public IQueryable<User> GetAllUsers()
        {
            return _context.User;
        }
        public User GetUserByEmailAddress(string Email)
        {
            return _context.User.FirstOrDefault(u => u.Email == Email);
        }

        public User GetUserById(int UserId)
        {
            User p = _context.User.Find(UserId);
            return p;
        }

        public bool Login(User user)
        {
            string encPassword = EncryptPassword(user.Password);

            User existingUser = _context.User.FirstOrDefault
               (u => u.Email == user.Email && u.Password == encPassword);

            if (existingUser == null || existingUser.Password != encPassword)
            {
                return false;
            }
            else
            {
                _session.SetInt32("Id", existingUser.Id);
                _session.SetString("Email", user.Email);
                return true;
            }
        }
        public void Logout()
        {
            _session.Remove("Id");
            _session.Remove("Email");
        }
        public bool IsUserLoggedIn()
        {
            int? userId = _session.GetInt32("Id");
            if (userId == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public int GetLoggedInUserId()
        {
            int? userId = _session.GetInt32("Id");
            if (userId == null)
            {
                return -1;
            }
            else
            {
                return userId.Value;
            }
        }
        public string GetLoggedInUserName()
        {
            return _session.GetString("Email");
        }
        public string GetLoggedInFirstname()
        {
            return _session.GetString("Firstname");
        }

        //Update

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            if (!IsUserLoggedIn())
            {
                return false;
            }

            User userToUpdate = GetUserById(GetLoggedInUserId());
            if (userToUpdate != null && userToUpdate.Password == EncryptPassword(oldPassword))
            {
                userToUpdate.Password = EncryptPassword(newPassword);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
        public User Update(User u)
        {
            User userToUpdate = GetUserById(u.Id);
            if (userToUpdate != null)
            {
                userToUpdate.Password = u.Password;
                userToUpdate.IsAdmin = u.IsAdmin;
                _context.SaveChanges();
            }
            return userToUpdate;
        }

        //Delete

        

        public bool Delete(int id)
        {
            User userToDelete = GetUserById(id);
            if (userToDelete == null)
            {
                return false;
            }
            _context.User.Remove(userToDelete);
            _context.SaveChanges();
            return true;
        }
        public bool Delete(User u)
        {
            return Delete(u.Id);
        }

        //   P r i v a t e   M e t h o d s

        private string EncryptPassword(string password)
        {
            //   SHA - Secure Hash Algorithm
            SHA256 hashAlgorithm = SHA256.Create();

            byte[] passwordArray = Encoding.ASCII.GetBytes(password);
            passwordArray[0] += 3;
            passwordArray[2] -= 5;

            byte[] encryptedPasswordArray =
               hashAlgorithm.ComputeHash(passwordArray);

            string result = BitConverter.ToString(encryptedPasswordArray);

            result = result.Replace("-", "");

            return result;
        }
        private string GenerateRandomPassword(int length = 8)
        {
            Random r = new Random();

            string result = "";
            for (int i = 0; i < length; i++)
            {
                result = result + (char)r.Next(33, 126);
            }

            return result;
        }
    }
}
