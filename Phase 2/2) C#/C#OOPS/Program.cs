using System;

namespace CSharpOOPs
{
    /* The concept of static:
    1) static meaning , the thing that dont changes or a common thing, that can be applied to all
    2) if you use static in the method, then you dont need to call the object ,
    you can directly access the method, using className.MethodName()

    simply , use static only when , you know that the method wont return diffrent for diffrent 
    objects and thus no need to call the objects, and simply use the class name to call it.

    But,you know why
    you really don't need to use static keyword, everytime
    but as a good practise, to avoid creating multiple objects, we use it

    for this --> as it contains diffrent parameters , so dont use static keyword
    class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }

    one more simple way---->Use static only when , you have
    diffrent inputs used in the method... */

    class ClassesObjects
    {
        /* lets understand classes and objects... */

        public string Name="";
        public void Display()
        {
            Console.Write($"\nHey{Name}, the function is started properly");
        }
    }
    class Constructor
    {
        /* A constructor's job is to initialize an object when you do new ClassName().
        But static means no object needed. So it's a contradiction —

        Constructor = for objects
        Static = no objects */

        /* Use :Constructor acts as a vehicle , that carries data from the object to the class
        rest of the work in the class is done by the DIFFRENT METHODS , for diffrent tasks */
        public string Name;
        public int Age;
        public Constructor(string name,int age)
        {   
            //notice diffrence between Upper and Lowercase letters
            Name=name;
            Age=age;
        } 
        public void Run()
        {
            Console.Write("");
            Console.WriteLine("\nUser Details :");
            Console.Write($"Name:{Name}");
            Console.Write($"\nAge:{Age}");
        }
    }
    class Program
    {
        static void Main(string[]args)
        {
            Console.Write("We are studying OOPs in C#");
            ClassesObjects s1=new ClassesObjects();
            ClassesObjects s2=new ClassesObjects();
            s1.Name="Che Guevara";
            s1.Display();
            s2.Name="Bharat Tiwari ";
            s2.Display();

            Constructor c1= new Constructor("Bhagat Singh",39);
            c1.Run();
        }

    }
    
  
}