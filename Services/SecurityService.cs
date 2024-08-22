using Minesweeper.Models;

namespace Minesweeper.Services
{
    public class SecurityService
    {
        List<UserModel> users = new List<UserModel>();

        public SecurityService() 
        {
            users.Add(new UserModel { 
                id = 0, 
                firstName = "First",
                lastName = "User",
                sex = "male",
                age = 20,
                state = "AZ",
                email = "user@one.com",
                userName = "User1", 
                password = "123"
            });

            users.Add(new UserModel
            {
                id = 1,
                firstName = "Second",
                lastName = "User",
                sex = "female",
                age = 35,
                state = "TX",
                email = "user@two.com",
                userName = "User2",
                password = "456"
            });

            users.Add(new UserModel
            {
                id = 3,
                firstName = "Third",
                lastName = "User",
                sex = "male",
                age = 23,
                state = "NY",
                email = "user@three.com",
                userName = "User3",
                password = "789"
            });
        }

        public bool IsValid(UserModel user)
        {
            return users.Any(x => x.userName == user.userName && x.password == user.password);
        }
    }
}
