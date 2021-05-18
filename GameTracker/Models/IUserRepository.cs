using System.Linq;

namespace GameTracker.Models
{
    public interface IUserRepository
    {
        //Create
        public User Create(User u);

        //Read
        public IQueryable<User> GetAllUsers();

        public User GetUserByEmailAddress(string Email);

        public User GetUserById(int Id);

        public bool Login(User u);

        public void Logout();

        public bool IsUserLoggedIn();

        public int GetLoggedInUserId();

        public string GetLoggedInUserName();

        public string GetLoggedInFirstname();



        //Update
        public bool ChangePassword(string oldPassword, string newPassword);

        public User Update(User u);

        //Delete
        public bool Delete(int id);

        public bool Delete(User u);
    }
}
