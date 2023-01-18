using System;
using System.Collections.Generic;
using System.Text;

namespace SharedProject1.Models
{
    class Senior : Person
    {
        private int reactionFlag = 0;
        public Senior(string username) : base(username)
        {
            Phrases = new string[] { "Hey", "You are such a jnr! Are you afraid of the Team Lead?" };
        }

        public override void Talk()
        {
            Console.WriteLine(Username + ": " + Phrases[0]);
            if(reactionFlag > 1)
            {
                Reaction();
                reactionFlag = 0;
            }
        }

        public void Reaction()
        {

            Console.WriteLine(Username + ": " + Phrases[1]);
        }

        public int RaiseFlag()
        {
            return reactionFlag++;
        }
    }
}
