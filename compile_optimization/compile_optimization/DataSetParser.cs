using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace compile_optimization
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
               
              
                dataSetInfo.compiledFiles=new List<CompiledFile>();
                for (int i = 0; i < dataSetInfo.numberCompiledFiles; i++)
                {
                    
                    var compiledFileInfo = file.ReadLine();
                    var compiledFileDependencies = file.ReadLine();
                    ProcessCompiledFile(compiledFileInfo, compiledFileDependencies);
                }

                for (int j = 0; j < dataSetInfo.numberTargetFiles; j++)
                {

                }

            }

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
            dataSetInfo.compiledFiles.Add(compiledFile);

        }

        private void ProcessHeader(string header)
        {
            var splittedFirstLine = header.Split(' ');

            dataSetInfo.numberCompiledFiles = int.Parse(splittedFirstLine[0]);
            dataSetInfo.numberTargetFiles = int.Parse(splittedFirstLine[1]);
            dataSetInfo.numberAvailableServers = int.Parse(splittedFirstLine[2]);
        }
    }
}
