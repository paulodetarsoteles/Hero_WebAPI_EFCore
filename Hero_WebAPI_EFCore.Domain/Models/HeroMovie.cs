﻿namespace Hero_WebAPI_EFCore.Domain.Models
{
    public class HeroMovie
    {
        public int HeroId { get; set; }
        public int MovieId { get; set; }

        public Hero Hero { get; set; }
        public Movie Movie { get; set; }
    }
}
