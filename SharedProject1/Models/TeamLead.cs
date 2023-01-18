namespace SharedProject1.Models
{
     class TeamLead : Person
    {
        private int reactionFlag = 0;

        private string triggerName;
        public TeamLead(string username) : base(username)
        {
            Phrases = new string[] { "Hey", "Of course, baby. Be ready to suffer " };
        }

        public override void Talk()
        {
            Console.WriteLine(Username + ": " + Phrases[0]);
            if (reactionFlag >= 1)
            {
                Reaction();
                reactionFlag = 0;
            }
        }

        private void Reaction()
        {

            Console.WriteLine(Username + ": " + Phrases[1] + triggerName + "!");
        }

        public void SetTriggerName(string name)
        {
            triggerName= name;
        }

        public int RaiseFlag()
        {
            return reactionFlag++;
        }
    }
}
