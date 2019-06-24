using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public int PublisherId { get; set; }
        public int Year { get; set; }
        public float Price { get; set; }

        public void Print()
        {
            System.Console.WriteLine($"{Title}, {PublisherId}, {Year}, {Price}");
        }
    }
}

