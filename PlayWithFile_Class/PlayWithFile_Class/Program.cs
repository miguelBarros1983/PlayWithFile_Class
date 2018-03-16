
namespace PlayWithFile_Class
{
    using System;
    using System.IO;
    using System.Text;

    public static class Program
    {
        public static void Main()
        {
            string CompletePath = $@"c:\FileClassFolder\TestFile.txt";
            string PathFolder = $@"c:\FileClassFolder";

            //Check if exist the directory needed, and if not we should create
            if (!Directory.Exists(PathFolder))
            {
                // Creating directory
                Directory.CreateDirectory(PathFolder);
            }

            try
            {
                //Verify if exist the path and the file
                if (File.Exists(CompletePath))
                {
                    // I exist we need to delete the file to permit use the code to create a new one
                    File.Delete(CompletePath);
                }

                // If not create the path and file
                using (FileStream fs = File.Create(CompletePath))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes("MiguelJQWHDJH???jhgashd!");
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(CompletePath))
                {
                    // Read the file until an empty line
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        // Console print
                        Console.WriteLine(s);
                    }
                }
            }
            // Generic exception to catch any error
            catch (Exception)
            {
                Console.WriteLine("Some error hapens!!!");
                throw;
            }

            Console.WriteLine("Prees enter do finish the presentation and check the next exercise!");
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadLine();

            Console.WriteLine(OpenDataFile(CompletePath));
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadLine();
        }


        public static string OpenDataFile(string FileName)
        {
            string result;

            // Check the FileName argument.
            if (FileName == null || FileName.Length == 0)
            {
                throw new ArgumentNullException("FileName");
            }

            // Check to see if the file exists.
            FileInfo fInfo = new FileInfo(FileName);

            // You can throw a personalized exception if 
            // the file does not exist.
            if (!fInfo.Exists)
            {
                throw new FileNotFoundException("The file was not found.", FileName);
            }

            // Open the stream and read it back.
            using (StreamReader sr = File.OpenText(FileName))
            {
                if (sr.ReadLine().Contains("Miguel"))
                {
                    result = $"Exist the word {0} in content of file";
                }
                else
                {
                    result = $"Doesn´t exist the word MIGUEL in content of file";
                }
            }

            // return the buffer.
            return result;

        }
    }
}
