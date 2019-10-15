using System;
using System.Threading.Tasks;
using DatingApp.API.models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly Datacontext _context;
        public AuthRepository(Datacontext context)
        {
            _context = context;

        }
        public async Task<user> Login(string username, string password)
        {
            var user=await _context.Users.FirstOrDefaultAsync(x=>x.Username==username);
            if(user==null)
            return null;
            if(!VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt))
            return null;

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
           using(var hmac=new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
          
              var computedHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
              for(int i=0;i<computedHash.Length;i++)
              {
                  if(computedHash[i]!=passwordHash[i])return false;
              }
            } 
            return true;  
        }

        public async Task<user> Register(user u, string password)
        {
            byte[] passwordHash,passwordSalt;
             CreatePasswordHash(password,out passwordHash,out passwordSalt);

            u.PasswordHash=passwordHash;
            u.PasswordSalt=passwordSalt;
            await _context.Users.AddAsync(u);
            await _context.SaveChangesAsync();
            return u;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac=new System.Security.Cryptography.HMACSHA512())
            {
               passwordSalt=hmac.Key;
                passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if(await _context.Users.AnyAsync(x=>x.Username==username))
            return true;
            
            return false;
        }
    }
}