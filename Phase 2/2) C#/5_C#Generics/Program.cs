/* What is Generics in C#
and wht do we need it 

Need-> if you want to store an integer in a varible, then you
simply create an integer varible
similiarly , if you want to store a string, you create a string 
varible
but 
instaed of this
if you replace the Data type by keyword T(Type)
then you can simply call the same varible,method or class
with diffrent objects with diffrent data type each time during 
compile time

this it helps you to use the same store box, diffrently 
depending upon situation
*/

using System;
namespace Generics
{
    /* Note :
    <T> is written for only situations
    1. For classes ex... class Example <T>
    2. For methods ex... public void Print<T>(T data)
        But note that ,If you are writing this function under a generic
        class, like right here , then you dont need to write <T>
        explicitly for a function */
    class Example<T>
    {
        public T? Value;
        public void Run()
        {
            Console.WriteLine("Value :"+Value);
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("---Generics in C#---");
            Example <int> e1=new Example<int>();
            e1.Value=100;
            e1.Run();

            Example <string> e2=new Example<string>();
            e2.Value="Che Guevara";
            e2.Run();

            Example <double> e3=new Example<double>();
            e3.Value=19.2333;
            e3.Run();
        }
    }
}