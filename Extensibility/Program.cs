using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensibility
{
    class Program
    {
        public interface ICompressor
        {
            void Compress();
        }

        public interface ILogger
        {
            void LogInfo(string message);

            void LogError(string message);
        }

        public class Compressor
        {
            private readonly ICompressor _compressor;
            public Compressor(ICompressor compressor)
            {
                this._compressor = compressor;
            }

            public void StartCompressing()
            {
                this._compressor.Compress();
            }
        }

        public class ConsoleLogger : ILogger
        {
            public void LogError(string message)
            {
                Log("ERROR", message);
            }

            public void LogInfo(string message)
            {
                Log("INFO", message);
            }

            protected void Log(string type, string message)
            {
                Console.WriteLine(type + " : " + message);
            }
        }

        public class DBLogger : ILogger
        {
            private readonly string _connectionString;
            public DBLogger(string dbConnectionString)
            {
                this._connectionString = dbConnectionString;
            }

            public void LogError(string message)
            {
                Log("DB : ERROR", message);
            }

            public void LogInfo(string message)
            {
                Log("DB : INFO", message);
            }

            // for testing only set it to console 
            protected void Log(string type, string message)
            {
                Console.WriteLine(type + " : " + message);
            }
        }

        public class FileCompressor : ICompressor
        {
            private readonly ILogger _logger;
            private readonly string _filePath;

            public FileCompressor(ILogger logger, string filePath)
            {
                this._logger = logger;
                this._filePath = filePath;
            }

            public void Compress()
            {
                _logger.LogInfo("File compression started at " + DateTime.Now);

                // compression logic

                _logger.LogInfo("File compression completed at " + DateTime.Now);
            }
        }

        public class DataCompressor : ICompressor
        {
            private readonly ILogger _logger;
            private readonly object _data;

            public DataCompressor(ILogger logger, object data)
            {
                this._logger = logger;
                this._data = data;
            }

            public void Compress()
            {
                _logger.LogInfo("Data compression started at " + DateTime.Now);

                // compression logic

                _logger.LogInfo("Data compression completed at " + DateTime.Now);
            }
        }

        static void Main(string[] args)
        {
            var compressor = new Compressor(new FileCompressor(new ConsoleLogger(), "D:\\file.txt"));
            compressor.StartCompressing();


            var dataCompressor = new Compressor(new DataCompressor(new DBLogger("localhot"), "string object"));
            dataCompressor.StartCompressing();

        }
    }
}
