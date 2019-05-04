using System;
using System.Collections.Generic;
using System.Text;

namespace compile_optimization
{
    public class DataSetInfo
    {
        public int numberCompiledFiles { get; set; }
        public int numberTargetFiles { get; set; }
        public int numberAvailableServers { get; set; }
        public List<CompiledFile> compiledFiles { get; set; }

    }

    public class CompiledFile
    {
        public string FileName { get; set; }
        public int CompileTime { get; set; }
        public int ReplicationTime { get; set; }
        public int numberCompiledFileDependencies { get; set; }
        public List<string> compiledFileDependencies { get; set; }
    }
}
