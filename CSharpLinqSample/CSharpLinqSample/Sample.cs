using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLinqSample
{
    public class Sample
    {
        private IConsole Console = new Console();

        public Sample()
        {

        }

        public Sample(IConsole console)
        {
            Console = console;
        }

        public int GetNumbers()
        {
            var numbers = new int[] {0 , 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var query = from number in numbers
                        where number > 6
                        select number;

            return query.Count();
        }

        public void GetNumbersOrdered()
        {
            var numbers = new int[] { 9, 1, 5, 8, 6, 7, 3, 2, 0, 4 };

            var query = from number in numbers
                        orderby number ascending
                        select number;

            foreach (var number in query)
            {
                Console.WriteLine(number);
            }
        }

        public void GetUsers(List<User> users)
        {
            var userQuery = from user in users
                            group user by user.Active into userGroup
                            select userGroup;

            foreach (var userGroup in userQuery)
            {
                Console.WriteLine("Active: {0}", userGroup.Key);
                foreach (var user in userGroup)
                {
                    Console.WriteLine(user.Name);
                }
            }
        }
    }

    public class Console : IConsole
    {
        public string Output { get; set; }

        public void WriteLine(int number)
        {
            System.Console.WriteLine(number);
        }

        public void WriteLine(string message)
        {
            System.Console.WriteLine(message);
        }

        public void WriteLine(string message, bool value)
        {
            System.Console.WriteLine(message, value);
        }
    }

    public interface IConsole
    {
        string Output { get; set; }

        void WriteLine(int number);
        void WriteLine(string message);
        void WriteLine(string message, bool value);
    }
}
