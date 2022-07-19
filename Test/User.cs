using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class User 
    {
        public string name;
#pragma warning disable CS0649 // Полю "User.status" нигде не присваивается значение, поэтому оно всегда будет иметь значение по умолчанию null.
        public string status;
#pragma warning restore CS0649 // Полю "User.status" нигде не присваивается значение, поэтому оно всегда будет иметь значение по умолчанию null.
#pragma warning disable CS0649 // Полю "User.score" нигде не присваивается значение, поэтому оно всегда будет иметь значение по умолчанию 0.
        public int score;
#pragma warning restore CS0649 // Полю "User.score" нигде не присваивается значение, поэтому оно всегда будет иметь значение по умолчанию 0.

      /*  public User(string name, string status, int score)
        {
            this.name = name;
            this.status = status;
            this.score = score;
        }*/

        public User SetName(string name)
        {
            this.name = name;
            return this;

        }


    }
}
