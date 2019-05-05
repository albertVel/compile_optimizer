using System;
using System.IO;
using compile_optimization;
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
          
                DataSetParser dataSetParser= new DataSetParser();

                dataSetParser.ReadFile(@"../../../DataSets/a_example.in");

                Assert.Equal(6,dataSetParser.dataSetInfo.numberCompiledFiles);
                Assert.Equal(3,dataSetParser.dataSetInfo.numberTargetFiles);
                Assert.Equal(2,dataSetParser.dataSetInfo.numberAvailableServers);

                Assert.Equal(6,dataSetParser.dataSetInfo.compiledFiles.Count);

                var dependendencies = dataSetParser.dataSetInfo.compiledFiles[5].compiledFileDependencies;
                Assert.Equal(2,dependendencies.Count);
                Assert.Equal("c2", dependendencies[0]);
                Assert.Equal("c3", dependendencies[1]);



        }

    }
}
