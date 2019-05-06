using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace CompileOptimization
{
    public class Optimizer
    {
        int currentTimeSpent;

        public List<CompiledDistribution> CompiledDistributions { get; private set; }

        public int GetScore(int deadline, int goalPoints, int compilationFinishTime)
        {
            var scoreValue = 0;
            if (currentTimeSpent < deadline)
            {
                scoreValue = deadline - compilationFinishTime + goalPoints;
            }

            return scoreValue;
        }

        public void ProcessDataSet(DataSetInfo dataSetInfo)
        {
            CompiledDistributions = new List<CompiledDistribution>();
            Dictionary<int, List<CompiledDistribution>> internalCompiledDistributions = new Dictionary<int, List<CompiledDistribution>>();

            var compiledFilesWithoutDependencies = from compiledFiles in dataSetInfo.CompiledFiles
                where compiledFiles.numberCompiledFileDependencies == 0
                select compiledFiles;

            var compiledFilesWithDependencies = from compiledFiles in dataSetInfo.CompiledFiles
                where compiledFiles.numberCompiledFileDependencies > 0
                select compiledFiles;


            for (int i = 0; i < dataSetInfo.NumberAvailableServers; i++)
            {
                internalCompiledDistributions[i]=new List<CompiledDistribution>();
            }

            foreach (var compiledFile in compiledFilesWithoutDependencies)
            {
                CompiledDistributions.Add(new CompiledDistribution(compiledFile.FileName,0));
                currentTimeSpent += compiledFile.CompileTime;
            }


            foreach (var compiledFileWithDependencies in compiledFilesWithDependencies)
            {
                CompiledDistribution compiledDistributionToAdd = new CompiledDistribution();
                foreach (var compiledDistribution in CompiledDistributions)
                {
                    var existsATargetFile = from targetFile in dataSetInfo.TargetFiles
                        where targetFile.FileName == compiledFileWithDependencies.FileName
                        select targetFile;

                    if (existsATargetFile.Count() != 0)
                    {

                    }

                    if (compiledFileWithDependencies.compiledFileDependencies.Contains(compiledDistribution.FileName))
                    {
                        compiledDistributionToAdd = new CompiledDistribution(compiledFileWithDependencies.FileName,0);
                        currentTimeSpent += compiledFileWithDependencies.CompileTime;
                        break;
                    }

                                    
                }

                if (compiledDistributionToAdd.FileName != string.Empty)
                {
                    CompiledDistributions.Add(compiledDistributionToAdd);
                }
            }
        }
    }
}