using System;

namespace DatingApp.API.models
{
    public class Photo
    {
        public int id { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public user user {get;set;}
        public int UserId { get; set; }
    }
}