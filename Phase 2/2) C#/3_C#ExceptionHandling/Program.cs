/* What is an Exception?

An exception is simply an error that occurs while
 the program is running. */

/* Thus in Prodcution-ready development
we always use the tru-catch blocks to handle the error smoothly
and return the error message, so that the developer atleast knows
what the issue is... */

using System;

namespace ExceptionHandling
{
    class Example
    {
        public void Run()
        {
            try
            {
                int Num1=10;
                int Num2=0;
                int Result=Num1/Num2;
                Console.WriteLine("Result is :"+Result);
            }
            catch (Exception e)
            /*we write here Exception Keyword, because in C#,Here Exception is
            the class that is creating an object e*/
            
            {   
                Console.WriteLine("Error Catched Successfully !"+e.Message);
            }
            /* And suppose an exception is already called
            and still you want to rexecute some code, then use Finally 
            so the code in the finally will execute 
            even if no exception occours,
            finally always executes...*/
            
        }
    }
    class Program
    {
        public static void Main(string[]args)
        {
            Console.WriteLine("---Exception Handling---");
            Example e1=new Example();
            e1.Run();
        }
    }
}