using System;

namespace DatingApp.API.Dtos
{
    public class UserforListDto
    {
         public int id{get;set;}
        public string Username{get;set;}
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Knownas{ get; set; }
        public DateTime Created { get; set; }
        public  DateTime LastActive { get; set; }
        //public string Introduction{ get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoUrl{ get; set; }
    }
}