using System.Collections.Generic;

namespace CompileOptimization
{
    public class DataSetInfo
    {
        public int NumberCompiledFiles { get; set; }
        public int NumberTargetFiles { get; set; }
        public int NumberAvailableServers { get; set; }
        public List<CompiledFile> CompiledFiles { get; set; }
        public List<TargetFile> TargetFiles { get; set; }
    }

    
}
