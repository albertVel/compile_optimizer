using System.Collections.Generic;
using System.IO;

namespace CompileOptimization
{
    public class DataWriter
    {
        private List<CompiledDistribution> compiledDistributions;
        private string fileName;


        public DataWriter(List<CompiledDistribution> compiledDistributions, string fileName)
        {
            this.compiledDistributions = compiledDistributions;
            this.fileName = fileName;
        }

        public void GenerateSubmission()
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
                file.WriteLine(compiledDistributions.Count);

                foreach (var compiledDistribution in compiledDistributions)
                {
                    file.WriteLine(compiledDistribution.FileName +' '+compiledDistribution.Server);
                }
            }
        }
    }
}