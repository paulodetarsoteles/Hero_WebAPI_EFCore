﻿namespace Hero_WebAPI_EFCore.Web.Models
{
    public class Secret
    {
        public int SecretId { get; set; }
        public string Name { get; set; }
        public int HeroId { get; set; }

        public Hero Hero { get; set; }
    }
}
