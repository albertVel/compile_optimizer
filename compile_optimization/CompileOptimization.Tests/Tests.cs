using System.Collections.Generic;
using System.Linq;
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

            DataWriter dataWriter = new DataWriter();

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

            //DataWriter dataWriter = new DataWriter();
            //List<CompiledDistribution> compiledDistributions= new List<CompiledDistribution>();
            ////dataWriter.GenerateSubmission("a_example.submission", compiledDistributions);
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

    public class Optimizer
    {
        public void ProcessDataSet(DataSetInfo dataSetInfo)
        {
            var compiledFilesWithoutDependencies = from compiledFiles in dataSetInfo.CompiledFiles
                where compiledFiles.numberCompiledFileDependencies == 0
                select compiledFiles;

            var compiledFilesWithDependencies = from compiledFiles in dataSetInfo.CompiledFiles
                where compiledFiles.numberCompiledFileDependencies > 0
                select compiledFiles;

            List<CompiledDistribution> compiledDistributions = new List<CompiledDistribution>();

            foreach (var compiledFile in compiledFilesWithoutDependencies)
            {
                compiledDistributions.Add(new CompiledDistribution(compiledFile.FileName,0));
            }
        }
    }

    public class CompiledDistribution
    {


        public CompiledDistribution(string fileName, int server)
        {
            this.FileName = fileName;
            this.Server = server;
        }

        public string FileName { get; set; }
        public int Server { get; set; }

    }
}
