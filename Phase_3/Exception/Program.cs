using System;

namespace ImportPipeline
{
    class ImportException : Exception
    {
        public ImportException(string message) : base(message)
        {
        }
    }

    class InvalidFormatException : ImportException
    {
        public InvalidFormatException(string message) : base(message)
        {
        }
    }

    class ImportService
    {
        public void Import(string fileName)
        {
            try
            {
                Validate(fileName);
                Parse(fileName);
                Save(fileName);
            }
            catch (InvalidFormatException ex)
            {
                Console.WriteLine($"FORMAT ERROR: {ex.Message}");
                throw;
            }
            catch (ImportException ex)
            {
                Console.WriteLine($"IMPORT ERROR: {ex.Message}");
            }
            finally
            {
                Cleanup(fileName);
            }
        }

        private void Validate(string file)
        {
            if (string.IsNullOrWhiteSpace(file))
                throw new ImportException("File name missing");

            if (!file.EndsWith(".csv"))
                throw new InvalidFormatException("Only CSV allowed");
        }

        private void Parse(string file)
        {
            Console.WriteLine("Parsing file");

            bool corrupted = true;
            if (corrupted)
                throw new ImportException("Corrupted data");
        }

        private void Save(string file)
        {
            Console.WriteLine("Saving data");
        }

        private void Cleanup(string file)
        {
            Console.WriteLine("Cleanup complete");
        }
    }

    class Program
    {
        static void Main()
        {
            var service = new ImportService();

            try
            {
                service.Import("data.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SYSTEM FAILURE: {ex.Message}");
            }
        }
    }
}
