namespace SharedProject1.Models
{
    class Senior : Person
    {
        private int reactionFlag = 0;
        public event Message TriggerSeniorMessage;
        public Senior(string username) : base(username)
        {
            Phrases = new string[] { "Hey", "You are such a jnr! Are you afraid of the Team Lead?" };
        }

        public override void Talk()
        {
            Console.WriteLine(Username + ": " + Phrases[0]);
            if(reactionFlag >= 1)
            {
                Reaction();
                reactionFlag = 0;
            }
        }

        private void Reaction()
        {

            Console.WriteLine(Username + ": " + Phrases[1]);
            TriggerSeniorMessage();
        }

        public int RaiseFlag()
        {
            return reactionFlag++;
        }
    }
}
