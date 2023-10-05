namespace Signicat.Infrastructure
{
    internal class FileContent
    {
        public FileContent(string filename, byte[] data)
        {
            this.FileName = filename;
            this.Data = data;
        }

        internal string FileName { get; set; }

        internal byte[] Data { get; set; }
    }
}