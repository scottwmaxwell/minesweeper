using Minesweeper.Models;

namespace Minesweeper.Services
{
    public class SecurityService
    {
        SecurityDAO securityDAO = new SecurityDAO();

        public bool IsValid(UserModel user)
        {
            return securityDAO.findUserByNameAndPassword(user);
        }

        public bool Save(UserModel user)
        {
            return securityDAO.addUser(user);
        }
    }
}
