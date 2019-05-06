using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Xunit;

namespace CompileOptimization.Tests
{
    public class Tests
    {
        [Fact]
        public void DummyTest()
        {
            Assert.True(true);
        }

        [Fact]
        public void ProcessExampleDataSet()
        {
            DataSetParser dataSetParser = new DataSetParser();

            dataSetParser.ReadFile(@"../../../DataSets/a_example.in");

            Optimizer optimizer = new Optimizer();

            optimizer.ProcessDataSet(dataSetParser.dataSetInfo);

            Assert.True(optimizer.CompiledDistributions.Count>=6);

            DataWriter dataWriter = new DataWriter(optimizer.CompiledDistributions,"a_example.out");

            dataWriter.GenerateSubmission();             

            Assert.True(File.Exists("a_example.out"));

        }

        [Fact]
        public void ReadExampleDataSet()
        {
            DataSetParser dataSetParser = new DataSetParser();

            dataSetParser.ReadFile(@"../../../DataSets/a_example.in");

            Assert.Equal(6, dataSetParser.dataSetInfo.NumberCompiledFiles);
            Assert.Equal(3, dataSetParser.dataSetInfo.NumberTargetFiles);
            Assert.Equal(2, dataSetParser.dataSetInfo.NumberAvailableServers);

            Assert.Equal(6, dataSetParser.dataSetInfo.CompiledFiles.Count);

            var dependendencies = dataSetParser.dataSetInfo.CompiledFiles[5].compiledFileDependencies;
            Assert.Equal(2, dependendencies.Count);
            Assert.Equal("c2", dependendencies[0]);
            Assert.Equal("c3", dependendencies[1]);

            Assert.Equal(3, dataSetParser.dataSetInfo.TargetFiles.Count);
            var lastTargetFile = dataSetParser.dataSetInfo.TargetFiles[2];
            Assert.Equal("c5", lastTargetFile.FileName);
            Assert.Equal(53, lastTargetFile.Deadline);
            Assert.Equal(35, lastTargetFile.GoalPoints);
        }

        [Fact]
        public void ReadBigDataSet()
        {
            DataSetParser dataSetParser = new DataSetParser();

            dataSetParser.ReadFile(@"../../../DataSets/f_big.in");

            Assert.Equal(9992, dataSetParser.dataSetInfo.NumberCompiledFiles);
            Assert.Equal(4336, dataSetParser.dataSetInfo.NumberTargetFiles);
            Assert.Equal(100, dataSetParser.dataSetInfo.NumberAvailableServers);

            Assert.Equal(9992, dataSetParser.dataSetInfo.CompiledFiles.Count);
            Assert.Equal(4336, dataSetParser.dataSetInfo.TargetFiles.Count);


        }

      
    }
}
