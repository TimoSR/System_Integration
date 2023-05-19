using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileHandlerLib.domain
{
    public class Person
    {
        public string? name { get; set; }
        public int age { get; set; }
        public string? email { get; set; }
        public Address? address { get; set; }

        public class Address
        {
            public string? street { get; set; }
            public string? city { get; set; }
            public string? state { get; set; }
            public string? zip { get; set; }
        }

    }
}