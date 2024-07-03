using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Entities
{
    public class Person
    {
        public int GameCategory {  get; set; }
        public required int[] Points { get; set; }
        public int AllPoints { get; set; } = 0;

    }
}
