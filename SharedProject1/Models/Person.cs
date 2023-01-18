namespace SharedProject1.Models
{
    public delegate int Message();
    abstract class Person
    {
        public string? Username { get; set; }
        public string? Role { get; set; }
        public int RoleId { get; set; }
        public string[] Phrases;

        public Person(string username)
        {
            Username = username;
        }
        public abstract void Talk();

    }
}
