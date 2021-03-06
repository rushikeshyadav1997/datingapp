using System;
using System.Collections.Generic;
using DatingApp.API.models;

namespace DatingApp.API.Dtos
{
    public class UserforDetailsDto
    {
         public int id{get;set;}
        public string Username{get;set;}
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Knownas{ get; set; }
        public DateTime Created { get; set; }
        public  DateTime LastActive { get; set; }
        public string Introduction{ get; set; }
        public string Lookingfor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<PhotoforDetailsDto> Photos{ get; set; }
    }
}