using System;
using System.Collections.Generic;

namespace DatingApp.API.models
{
    public class user
    {
        public int id{get;set;}
        public string Username{get;set;}
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Knownas{ get; set; }
        public DateTime Created { get; set; }
        public  DateTime LastActive { get; set; }
        public string Introduction{ get; set; }
        public string Lookingfor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<Photo> Photos{ get; set; }
        
    }
}