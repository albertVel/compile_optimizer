using System.Collections.Generic;

namespace CompileOptimization
{
    public class CompiledFile
    {
        public string FileName { get; set; }
        public int CompileTime { get; set; }
        public int ReplicationTime { get; set; }
        public int numberCompiledFileDependencies { get; set; }
        public List<string> compiledFileDependencies { get; set; }
    }
}
