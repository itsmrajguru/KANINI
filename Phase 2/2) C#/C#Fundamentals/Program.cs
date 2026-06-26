/* C# Fundamentals */


/* Before starting the actual code, let s undersatnd the structure of the c# language  

1) using System;  --> this makes the system word common, so that 
we dont need to use it eveyrtime before every console.WriteLine or I/O operations 
{std::}

2) namespace   --> it is the container that is used to group similiar classes together
-->it is must to use atleast one namespace in eac project

3) class class_name --> C# is pure OOP based language , so it is must to create classes for
diffrent functionalties 

4) static void Main(string[]args) -->CLR(common Language RunTime) searches this function only
to execute the program {int main(){}}
--> a) static--> always used everywhere for each function
    b) void --> returns nothing
    c)string[]args -->it creates a string of the arguments passed with each compilation

*/



using System;
using Microsoft.VisualBasic;
using Microsoft.Win32.SafeHandles;
namespace Hello
{
    class Fundamentals
    {
        /* This class covers C# fundamentals, like I/O, variables , Data Types, Typecasting
        etc.. 
        a)I/O 
        {cout<<" "}; --> Console.WriteLine() --> write and go to next line
                        & Console.Write()--> write only

        {cin>>;}   --> Console.ReadLine() -->Takes input as string
                        & Console.Read()--> Takes the first character of string and returns its ASCII value
        */
        public static void Run()
        {

            Console.WriteLine("\n-----C# Fundamentals-----");
            
            Console.Write("Enter your name :");
            string? Name=Console.ReadLine();

            Console.Write("Enter your age :");
            int Age=int.Parse(Console.ReadLine()!);

            Console.Write("Enter your CGPA :");
            double Cgpa=double.Parse(Console.ReadLine()!);
            

            Console.WriteLine("Details of the student:");Console.WriteLine();
            Console.WriteLine($"Name:{Name}");
            Console.WriteLine($"Age:{Age}");
            Console.WriteLine($"CGPA:{Cgpa}");
        }

    }

    class Conditionals
    {
        /* for both c++ and C# , syntax of conditionals is exactly similiar */
        public static void Run()
        {
            Console.WriteLine("\n-----C# Conditionals-----");

            Console.Write("Enter your Age :");
            int age=int.Parse(Console.ReadLine()!);

            if (age > 18)
            {
                Console.Write("You are eligible for Vote");
            }
            else
            {
                Console.Write("You are NOT eligible for Vote");

            }

            Console.Write();
            Console.Write("\nEnter your marks (0-100): ");
            int marks = int.Parse(Console.ReadLine()!);

            if (marks >= 90)
            {
                Console.WriteLine("Grade : A");
            }
            else if (marks >= 75)
            {
                Console.WriteLine("Grade : B");
            }
            else if (marks >= 60)
            {
                Console.WriteLine("Grade : C");
            }
            else if (marks >= 40)
            {
                Console.WriteLine("Grade : D");
            }
            else
            {
                Console.WriteLine("Grade : F (Fail)");
            }
        }
    }

    class Loops
    {
        /* for both c++ and C# , syntax of Loops is also exactly similiar */
        public static void Run()
        {
            Console.WriteLine("\n-----Loops in C#-----");

            /* For Loop ex...Printing table of 15 */
            Console.WriteLine("1) For Loop");

            for(int i=0; i<=10; i++)
            {
                Console.Write(i*15);
            }
            Console.Write();

            /* While Loop... printing numbers from 1 to 5*/
            Console.WriteLine("2) While Loop");

            int j=1;
            while (j <= 5)
            {
                Console.Write(j+"");
                j++;
            }

            /* ForEach Loop */
            Console.WriteLine("4) Foreach Loop");

            string[] fruits =
            {
                "Apple",
                "Banana",
                "Mango",
                "Orange"
            };
            foreach(string i in fruits)
            {
                Console.Write(i+" ");
            }

            /* Break Statement */
            Console.WriteLine("5) Break Statement");
            for (int i = 1; i <= 10; i++)
            {
                if (i == 6)
                {
                    break;
                }
                Console.Write(i + " ");
            }
            Console.WriteLine("\n");

            /*  Continue Statement */
            Console.WriteLine("6) Continue Statement");

            for (int i = 1; i <= 10; i++)
            {
                if (i == 6)
                {
                    continue;
                }
                Console.Write(i + " ");
            }
            Console.WriteLine("\n");
        }
    }

    class Arrays
    {
        public static void Run()
        {
            Console.WriteLine("\n-----Arrays in C#------\n");

           /* Declaring an Array:
            {int arr[]={}} -->int[] arr={};*/

            Console.WriteLine("Declaring an Array :");
            int[] arr1={10,20,30,40,50};

            /* Initializing the array :*/
            int[]arr2;
            arr2= new int[]{1,2,3,4,5,};

            /* 
            2)Printing Array Elements :
            {no .length function} --> It contains .length function to return the length of the array
                                    and this helps us to run the loop over the array*/
            Console.WriteLine("2) Printing Array Elements");
            for(int i = 0; i < arr2.Length; i++)
            {
                Console.Write(i+" ");
            }

            /* Accsseing Indivisual Elements */
            Console.WriteLine("3) Accessing Elements");

            Console.WriteLine("First Element : " + numbers[0]);
            Console.WriteLine("Last Element  : " + numbers[numbers.Length - 1]);

            Console.WriteLine();

            /* updating an Element */
            Console.WriteLine("4) Updating an Element");
            arr2[2] = 100;
            Console.WriteLine("Updated Third Element : " + numbers[2]);
            Console.WriteLine();

            /* taking Array Input */
            Console.WriteLine("5) Taking Array Input :");
            int[] arr3;
            arr3=new int[]{9,8,7,6,5};

            for(int i = 0; i < arr3.Length; i++)
            {
                arr3[i]=int.Parse(Console.ReadLine()!);
            }

            // 6) Printing User Array
            Console.WriteLine("5) Printing User Array using ForEach Function");
            foreach (int value in arr3)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine("\n");
        }
    }    

    class Strings
    {
        public static void Run()
        {
            Console.WriteLine("\n-----strings in C#------\n");

            // 1) Declaring and Initializing Strings
            Console.WriteLine("1) Declaring Strings");
            string firstName = "Mangesh";
            string lastName = "Rajguru";

            Console.WriteLine("First Name : " + firstName);
            Console.WriteLine("Last Name  : " + lastName);

            Console.WriteLine();

            // 2) String Concatenation
            Console.WriteLine("2) String Concatenation");
            string fullName = firstName + " " + lastName;
            Console.WriteLine("Full Name : " + fullName);

            Console.WriteLine();


            // 3) String Interpolation
            Console.WriteLine("3) String Interpolation");
            Console.WriteLine($"Welcome {fullName}");

            Console.WriteLine();


            // 4) String Length
            Console.WriteLine("4) String Length");
            Console.WriteLine("Length = " + fullName.Length);

            Console.WriteLine();

            // 5) Uppercase and Lowercase
            Console.WriteLine("5) Uppercase and Lowercase");
            Console.WriteLine(fullName.ToUpper());
            Console.WriteLine(fullName.ToLower());

            Console.WriteLine();

            // 6) Accessing Characters
            Console.WriteLine("6) Accessing Characters");
            Console.WriteLine("First Character : " + fullName[0]);
            Console.WriteLine("Last Character : " + fullName[fullName.Length - 1]);

            Console.WriteLine();

            /* 7)  There are lot of such opeartions like

            StartsWith() and EndsWith(), Replace(), Substring(), Trim(), Equals(),
            Compare(), Split() */

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Fundamentals.Run();
            Conditionals.Run();
            Loops.Run();
            Arrays.Run();
            Strings.Run();
        }
    }
}