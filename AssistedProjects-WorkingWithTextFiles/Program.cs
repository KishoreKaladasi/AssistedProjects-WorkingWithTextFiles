using System;
using System.IO;


namespace Phase1Section3._12
{
    class Program
    {
        static void Main(string[] args)
        {

            CreateAndWriteTXTFile();

            OpenAndReadTXTFile();

            AppendAndWriteTxtFile();

            OpenAndReadTXTFile();



            Console.Read();


        }

        private static void AppendAndWriteTxtFile()
        {
            //checking file is in the given location or NOT if not it goes to else block
            bool ans = File.Exists(@"C:\Users\ASUS\source\repos\Assignment9-FileHandling withTXT-files\Persons.txt");
            if (ans == true)
            {
                //this command used to open the file and read it ... 
                FileStream fs = new FileStream(@"C:\Users\ASUS\source\repos\Assignment9-FileHandling withTXT-files\Persons.txt", FileMode.Append, FileAccess.Write);
                StreamWriter appending = new StreamWriter(fs);
                //this try catch block used to if there any exceptions catch block executed otherwise try executed

                try
                {
                    appending.WriteLine("Micheal is a .NET Developer");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    appending.Close();
                    appending.Dispose();
                    fs.Close();
                    fs.Dispose();
                }

            }
            else
            {
                Console.WriteLine("file does'nt exist on your given location");
            }
        }

        private static void OpenAndReadTXTFile()
        {
            //checking file is in the given location or NOT if not it goes to else block
            bool ans = File.Exists(@"C:\Users\ASUS\source\repos\Assignment9-FileHandling withTXT-files\Persons.txt");
            if (ans == true)
            {
                //this try catch block used to if there any exceptions catch block executed otherwise try executed
                try
                {
                    //this command used to open the file and read it ... 
                    FileStream fs = new FileStream(@"C:\Users\ASUS\source\repos\Assignment9-FileHandling withTXT-files\Persons.txt", FileMode.Open, FileAccess.Read);
                    StreamReader reading = null;
                    //this try catch block used to if there any exceptions catch block executed otherwise try executed
                    try
                    {
                        //Retrieve the data from the file to readme string ..and print it in console..
                        reading = new StreamReader(fs);
                        string readme = reading.ReadToEnd();
                        Console.WriteLine(readme);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        fs.Close();
                        fs.Dispose();
                        reading.Close();
                        reading.Dispose();

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            else
            {
                Console.WriteLine("File does'nt exist on the given location");
            }
        }

        private static void CreateAndWriteTXTFile()
        {
            //creating a txt file by giving location
            FileStream fs = new FileStream(@"C:\Users\ASUS\source\repos\Assignment9-FileHandling withTXT-files\Persons.txt", FileMode.Create, FileAccess.Write);
            //creating a obj for writing
            StreamWriter writing = new StreamWriter(fs);
            //lets assign text to fieds with object
            try
            {
                writing.WriteLine("Name of the Person : Micheal");
                writing.WriteLine("Adress of the person : Texas, USA ,America ,Area 251");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //flush means the buffer data if anything is remaining will be written to the file
                writing.Flush();
                //close and save
                writing.Close();
                writing.Dispose();
                fs.Close();
                fs.Dispose();
            }
        }
    }
}
