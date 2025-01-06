﻿namespace MovieApi.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }   
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime ReleasedDay { get; set; }

    }

    
}
