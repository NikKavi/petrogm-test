using System;
using System.Collections.Generic;
using System.Text;

namespace SharedProject1.Models
{
    abstract class Person
    {
        public string? Username { get; set; }
        public string? Role { get; set; }
        public int RoleId { get; set; }
        public string[]? Phrases;

        public Person(string username)
        {
            Username = username;
        }
        public abstract void Talk();

    }
}
