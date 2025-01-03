﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LIBDG
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public Person() { }

        public Person(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public abstract void Login();
    }
}

