using FitnessTrackerApp.Exceptions;
using FitnessTrackerApp.Model;
using FitnessTrackerApp.Utility;
using System.Collections.Generic;

namespace FitnessTrackerApp.Service
{
    public class UserService
    {
        public bool Login(string username, string password)
        {
            List<User> allUsers = DataStorage.LoadData<User>();

            foreach (User user in allUsers)
            {
                if (string.Equals(user.UserName, username, System.StringComparison.OrdinalIgnoreCase))
                {
                    return user.Password == password;
                }
            }

            return false;
        }

        public User GetUserByName(string username)
        {
            List<User> allUsers = DataStorage.LoadData<User>();

            foreach (User user in allUsers)
            {
                if (string.Equals(user.UserName, username, System.StringComparison.OrdinalIgnoreCase))
                {
                    return user;
                }
            }

            return null;
        }

        public void AddNewUser(User newUser)
        {
            List<User> allUsers = DataStorage.LoadData<User>();

            if (GetUserByName(newUser.UserName) != null)
            {
                throw new UserNameAlreadyExistsExeption(newUser.UserName);
            }

            allUsers.Add(newUser);
            DataStorage.SaveData(allUsers);
        }

        public void DeleteUser(string username)
        {
            List<User> allUsers = DataStorage.LoadData<User>();
            User userToDelete = GetUserByName(username);

            if (userToDelete == null)
            {
                throw new UserNameNotFoundException(username);
            }

            allUsers.Remove(userToDelete);
            DataStorage.SaveData(allUsers);
        }

        public void UpdateUser(User updatedUser)
        {
            List<User> allUsers = DataStorage.LoadData<User>();
            User existingUser = GetUserByName(updatedUser.UserName);

            if (existingUser == null)
            {
                throw new UserNameNotFoundException(updatedUser.UserName);
            }

            existingUser.Name = updatedUser.Name;
            existingUser.Password = updatedUser.Password;
            existingUser.Height = updatedUser.Height;
            existingUser.Gender = updatedUser.Gender;
            existingUser.DateofBirth = updatedUser.DateofBirth;

            DataStorage.SaveData(allUsers);
        }

        public List<User> GetAllUsers()
        {
            return DataStorage.LoadData<User>();
        }
    }
}