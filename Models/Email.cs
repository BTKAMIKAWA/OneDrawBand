using System;

namespace OneDraw.Models
{
    public class Email
    {
        public string name{get; set;}
        public string email{get; set;}
        public string comments{get; set;}
        public DateTime CreatedAt{get;set;} = DateTime.Now;

    }
}