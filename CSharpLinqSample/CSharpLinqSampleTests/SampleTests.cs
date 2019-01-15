using CSharpLinqSample;
using System;
using System.IO;
using Xunit;

namespace CSharpLinqSampleTests
{
    public class SampleTests
    {
        [Fact]
        public void GetNumbersTest()
        {
            var sample = new Sample();
            var result = sample.GetNumbers();

            // Regex file for basic LINQ structure `from * in * where * select *`
            // Assert regex found a match

            Assert.True(result == 3);
        }

        [Fact]
        public void GetNumbersOrderedTest()
        {
            var console = new TestConsole();
            var sample = new Sample(console);

            // Regex file for basic LINQ structure `from * in * orderby * ascending * select *`
            // Assert regex found a match

            sample.GetNumbersOrdered();

            Assert.True(console.Output == "0123456789");
        }
    }

    public class TestConsole : IConsole
    {
        public string Output { get; set; } = string.Empty;

        public void WriteLine(int number)
        {
            Output += number;
        }

        public void WriteLine(string message)
        {
            Output += message;
        }

        public void WriteLine(string message, bool value)
        {
            Output += message + value;
        }
    }
}
