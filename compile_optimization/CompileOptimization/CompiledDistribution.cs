namespace CompileOptimization
{
    public class CompiledDistribution
    {
        public CompiledDistribution()
        {
            this.FileName = "";
            this.Server = -1;
        }
        public CompiledDistribution(string fileName, int server)
        {
            this.FileName = fileName;
            this.Server = server;
            
        }

        public string FileName { get; set; }
        public int Server { get; set; }

    }
}