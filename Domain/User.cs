using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public string Nickname { get; set; }
        public DateTime TimeSent { get; set; }
        public string Message { get; set; }

        public User Random()
        {

            Nickname = RandomStringCombination();
                

            TimeSent = DateTime.Now;

            Message = RandomStringCombination();

            return this;
        }

        public string RandomStringCombination()
        {
            Random rand = new Random();
            return string.Join("", Enumerable.Range(1, 10).Select(element => ((Char)rand.Next(1, 200))).ToArray());

        }

        public override string ToString()
        {
            return string.Format("({0:HH:MM}) {1}: {2}", TimeSent, Nickname, Message);
        }
    }
}
