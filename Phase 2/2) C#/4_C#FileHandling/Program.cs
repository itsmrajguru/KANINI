/* What is File Handling ?

as you can create,read,update and delete the files on the application
whatsapp and mobile Device
similiarly you can do it throgh the programs

means you can create,read,update and delete the files through the programs*/

using System;
using System.IO;
namespace FileHandling
{
    /* We need System.IO for file Handling */
    class Example
    {
        public void Run()
        {
        /* 1) Writinng a file 
        --> It overwrites a file ,if exists
            or creates a new file and write , if does not exists...*/

            File.WriteAllText("demo.txt","Hello Che");

        /* 2) Reading a File 
        --> It simply returns the text from the file..
        Note :It returns the data , not prints.
                To print the data, you have to store the data in varible
                and print using Console.Write()*/

            string data=File.ReadAllText("demo.txt");
            Console.WriteLine(data);
        /* 3) Appending a File 
        --> It adds content on the same line*/

            File.AppendAllText("demo.txt","\nHello to both Che and Bhagat !");

            /* 4) Deleting File*/
            /* File.Delete("demo.txt"); */

            /* 5) If File Exists() Function  */
            if (File.Exists("demo.txt"))
            {
                Console.WriteLine("File Found !");
            }
            else
            {
                Console.WriteLine("File Not Found !");
            }
            /* 6) Read All lines() 
            -->read lines one by one using Loop 
            but for that we first create an array and store all content 
            from file in it 
            and then run a loop on the Array*/
            string[] Lines=File.ReadAllLines("demo.txt");
            foreach(string line in Lines)
            {
                Console.WriteLine(line);
            }
            /* 7) Write All lines() 
            --> Write all lines from an array into the file 
            so we create an array with all lines sepearated by commas and store all in the array */
            string[] quotes =
            {
                "Che Guevara",
                "Bhagat Singh",
                "Lenin",
                "Bakunin"
            };
            File.WriteAllLines("Quotes.txt",quotes);

        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("---File Handling---");
            Example e1=new Example();
            e1.Run();
        }
    }
}