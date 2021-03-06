using System.Threading.Tasks;
using DatingApp.API.models;

namespace DatingApp.API.Data
{
    public interface IAuthRepository
    {
         Task<user> Register(user u,string password);
         Task<user> Login(string username,string password);
         Task<bool> UserExists(string username); 
    }
}