using System;
using System.IO;
using Xunit;
using Xunit.Sdk;

namespace tests_compiler
{
    public class Tests
    {
        [Fact]
        public void DummyTest()
        {
            Assert.True(true);
        }

        [Fact]
        public void ReadExampleDataSet()
        {
            using (StreamReader file = new StreamReader(@"../../../DataSets/a_example.in"))
            {
                var firstLine = file.ReadLine();
                var splittedFirstLine = firstLine.Split(' ');

                var numberCompiledFiles = int.Parse(splittedFirstLine[0]);
                var numberTargetFiles = int.Parse(splittedFirstLine[1]);
                var numberAvailableServers = int.Parse(splittedFirstLine[2]);

                Console.WriteLine(numberTargetFiles);

                Console.WriteLine(numberCompiledFiles);

                Console.WriteLine(numberAvailableServers);

            }

        }
    }
}
