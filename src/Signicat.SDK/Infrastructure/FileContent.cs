using System.IO;

namespace Signicat.Infrastructure
{
    internal class FileContent
    {
        public FileContent(string filename, byte[] data)
        {
            this.FileName = filename;
            this.Data = data;
        }
        
        public FileContent(string filename, Stream streamData)
        {
            this.FileName = filename;
            this.StreamData = streamData;
        }

        internal string FileName { get; set; }

        internal byte[] Data { get; set; }
        
        internal Stream StreamData { get; set; }
    }
}