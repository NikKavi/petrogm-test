namespace SharedProject1.Models
{
    class User : Person
    {
        public User(string username) : base(username) 
        {
            Phrases = new string[] {"Hey"};
        }
        
        public override void Talk()
        {
            Console.WriteLine(Username + ": " + Phrases[0]);
        }
        
    }
}
