﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SharedProject1.Models
{
    class Junior : Person
    {
        public Junior(string username) : base(username)
        {
            Phrases = new string[] { "Hey", "I want a merge. Will somebody review it for me?" };
        }

        public override void Talk()
        {
            Console.WriteLine(Username + ": " + Phrases[0]);
            Console.WriteLine(Username + ": " + Phrases[1]);
        }

    }
}