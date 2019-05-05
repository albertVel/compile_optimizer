using System.Collections.Generic;
using System.IO;

namespace CompileOptimization
{

    public class DataSetParser
    {
        public DataSetInfo dataSetInfo { get; set; }
        public void ReadFile(string fileToRead)
        {
            dataSetInfo = new DataSetInfo();
            using (StreamReader file = new StreamReader(fileToRead))
            {
                ProcessHeader(file.ReadLine());
               
              
                dataSetInfo.CompiledFiles=new List<CompiledFile>();
                for (int i = 0; i < dataSetInfo.NumberCompiledFiles; i++)
                {
                    
                    var compiledFileInfo = file.ReadLine();
                    var compiledFileDependencies = file.ReadLine();
                    ProcessCompiledFile(compiledFileInfo, compiledFileDependencies);
                }

                dataSetInfo.TargetFiles = new List<TargetFile>();

                for (int j = 0; j < dataSetInfo.NumberTargetFiles; j++)
                {
                    var targetFileInfo = file.ReadLine();
                    dataSetInfo.TargetFiles.Add(ProcessTargetFile(targetFileInfo));
                }

            }

        }

        private TargetFile ProcessTargetFile(string targetFileInfo)
        {
            TargetFile targetFile = new TargetFile();

            var splittedTargetFile = targetFileInfo.Split(' ');

            targetFile.FileName = splittedTargetFile[0];
            targetFile.Deadline = int.Parse(splittedTargetFile[1]);
            targetFile.GoalPoints = int.Parse(splittedTargetFile[2]);

            return targetFile;
        }

        private void ProcessCompiledFile(string compiledFileInfo, string compiledFileDependencies)
        {
            CompiledFile compiledFile = new CompiledFile();


            var splittedCompiledFileInfo = compiledFileInfo.Split(' ');

            compiledFile.FileName = splittedCompiledFileInfo[0];
            compiledFile.CompileTime= int.Parse(splittedCompiledFileInfo[1]);
            compiledFile.ReplicationTime = int.Parse(splittedCompiledFileInfo[2]);

            var splittedCompiledFileDependencies = compiledFileDependencies.Split(' ');

            compiledFile.numberCompiledFileDependencies = int.Parse(splittedCompiledFileDependencies[0]);

            compiledFile.compiledFileDependencies=new List<string>();
            for (int i = 0; i < compiledFile.numberCompiledFileDependencies; i++)
            {
                compiledFile.compiledFileDependencies.Add(splittedCompiledFileDependencies[i+1]);
            }
            dataSetInfo.CompiledFiles.Add(compiledFile);

        }

        private void ProcessHeader(string header)
        {
            var splittedFirstLine = header.Split(' ');

            dataSetInfo.NumberCompiledFiles = int.Parse(splittedFirstLine[0]);
            dataSetInfo.NumberTargetFiles = int.Parse(splittedFirstLine[1]);
            dataSetInfo.NumberAvailableServers = int.Parse(splittedFirstLine[2]);
        }
    }
}
