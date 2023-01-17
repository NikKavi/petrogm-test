using System;
using SharedProject1.Models;

namespace petrotest
{
    public class Program
    {
        static void Main(string[] args)
        {
            string userName = "UserName";
            string juniorName = "JuniorName";
            User user = new(userName);
            user.Talk();
            Junior junior = new(juniorName);
            junior.Talk();
        }
    }
}