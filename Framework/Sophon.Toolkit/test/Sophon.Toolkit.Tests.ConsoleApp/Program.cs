using Sophon.Toolkit.Sophon.Util;
using System;

namespace Sophon.Toolkit.Tests.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var cnName = FakerUtil.GetOneChineseName();
            Console.WriteLine(cnName);
            var phoneNumber = FakerUtil.GetOnePhoneNumber();
            Console.WriteLine(phoneNumber);
        }
    }
}
