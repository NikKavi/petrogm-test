namespace SharedProject1.Models
{
     class Middle : Person
    {
        public event Message TriggerMiddleMessage;

        private int reactionFlag = 0;
        public Middle(string username) : base(username)
        {
            Phrases = new string[] { "Hey", "I want a merge. Will somebody review it for me?", "AAAAaaa! No! No TL code review, please!" };
        }

        public override void Talk()
        {
            Console.WriteLine(Username + ": " + Phrases[0]);
            Console.WriteLine(Username + ": " + Phrases[1]);
            TriggerMiddleMessage();
            if(reactionFlag >= 1)
            {
                Reaction();
                reactionFlag = 0;
            }
        }

        private void Reaction()
        {
            Console.WriteLine(Username + ": " + Phrases[2]);
        }

        public int RaiseFlag()
        {
            return reactionFlag++;
        }

    }
}
