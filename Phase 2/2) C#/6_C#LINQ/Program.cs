/* What is LINQ

--> It stands for Language Integrated Queries
--> It is SQL in C#
-->It lets you Appply queries on the collections (arrays, lists, dictionaries, databases, XML, etc.)
using C# syntax instead of writing loops manually. */

using System;
namespace LINQ
{
    /* Note : We need System.Linq for LINQ */
    class Example
    {
        /*  Method                  Easy Meaning

            Where()                 Filter
            Select()	            Choose columns / Transform
            OrderBy()	            Sort ↑
            OrderByDescending()	    Sort ↓
            FirstOrDefault()	    Get first safely
            Any()	                Exists?
            Count()	                Count
            Sum()	                Total
            Max()	                Highest
            Min()               	Lowest
            Average()	            Average
            Distinct()	            Remove duplicates
            Take()	                First N
            Skip()	                Skip N
            ToList()            	Execute query & convert to List
 */
        public void Run()
        {
            Console.Write("We will study it later !");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---LINQ---");
            Example e1=new Example();
            e1.Run();
        }
    }
}