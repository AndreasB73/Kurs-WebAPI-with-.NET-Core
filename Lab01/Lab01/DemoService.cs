using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01
{
    public class DemoService : IDemoService
    {
        public string Greet(string firstname, string name) => $"Hallo {firstname} {name}";
    }
}
