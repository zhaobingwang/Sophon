using Sophon.Toolkit.Faker;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Sophon.Toolkit.Tests.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomFaker randomFaker = new RandomFaker();
            List<Student> list=new List<Student>();
            var student = randomFaker.GetList(list, null);
            Console.WriteLine(randomFaker.GetBool());
        }
    }
}
