using System;
using CSharpOOPs.Polymorphism;
using CSharpOOPs.Abstraction;

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
            Console.Write("-----");
            Console.WriteLine("\n-----User Details-----");
            Console.Write($"Name:{Name}");
            Console.Write($"\nAge:{Age}");
        }
    }
    class ThisKeyword
    {
        /* This keyWord is basically used to fix the confustion betreen actual variable
        and instane created by Constructor
        
        Need--> So when the constructor is acting as driver,that transports the data
        from objects to classes, 
        then we need to explicitievly type
        Name=name , because , the name is a current instance creataed by the constructor
        so we need to put Name(actual Varible) equal to the name(instance created by class)
        thus to avoid confusion, this keyword represents the actual variable Name and takes
        data from the instance*/
        public string Idol_name;
        public ThisKeyword(string n)
        {
            this.Idol_name=n;
        }
        public void Display()
        {
            Console.Write($"\nIdol Name:{Idol_name}");
        }
    }

    class Encapsulation
    {
        /* What is Encapsulation?
        --> Hiding the internal data of a class and only exposing what is necessary.
        Think of it like a capsule 💊 — medicine is hidden inside, you only
        interact with the outer shell. */


        /* So basically, Encapsulation is wrapping the data inside private and exposing
         it safely through public methods — just like an ATM, where you can't touch the
          cash directly, you can only access it through the machine." */
        
        /* simply, wrap the imported data into the Private access Specifier
        so that,those data can be accessed by the public methods only, and 
        through the same class only */

        //create 2 methods for deposit and getBalance
        private int Balance;  //This is hided from external system
        public void Deposit(int amount)
        {
            if (amount > 0)
                Balance+=amount;
            else
                Console.Write("Invalid Amount !");
            Console.Write("-----");

        } 
        public int ShowBalance()
        {
            return Balance;
        }
    }
    class Inheritance
    {
        /* What is Inheritance?
        --> Child class inherits properties and methods from Parent class.
            So you don't rewrite the same code again — just reuse it.
        --> Also the child class can have exra properties along with the existing properties*/
        public string Name="";
        public void Run()
        {
            Console.Write($"\n{Name} is running...");
        }
        
        /* Types of Inheritance 
        1) Single Inheritance - one parent, one child
            class Animal { }
            class Dog : Animal { }
        
        2) Multiple Inheritance- 
            Not Allowed in C#
            Because--> Compiler gets confused , that 
            "iska real bap kaun hai ?"
        
        3) Multilevel Inheritance — chain of inheritance
            class Animal { }
            class Dog : Animal { }
            class Puppy : Dog { }  // Puppy → Dog → Animal

        4) Hierarchical Inheritance — one parent, multiple children
            class Animal { }
            class Dog : Animal { }
            class Cat : Animal { }  // both inherit from same parent
          */
    }
    class Dog : Inheritance
    {
        /* This is child class,inherited from Parent class Inheritance
        thus it can use the varible "Name" and Method "Run" from the parent class and
        also add some extra classes and methods */
        public void Bark()
        {
            Console.Write($"\n{Name} is barking...");
        }
    }
    namespace Polymorphism
    {
        class MethodOverloading
        {
            /* What is MethodOverloading?
            --> Same method name, different behavior — either via different parameters(overloading) or 
            via parent-child redefining (overriding). 

                
            types of Ploymorsphism :
                1. Compile Time  (Method Overloading)
                2. Run Time      ( Method Overriding) 
            */
            
            /* 1. Method Ovrloading 
            --> Compiler decides at compile time which Add() to call — based on parameters.*/

            public int add(int n1,int n2)
            {
                return n1+n2;
            }
            public int add(int n1,int n2,int n3)
            {
                return n1+n2+n3;
            }
            public double add(double n1,double n2)
            {
                return n1+n2;    
            }
        }
        class Animal
        {
            public virtual void Bark()
            {
                Console.WriteLine("ISI is Barking like a Dog");
            }
        }
        class OverridedDog:Animal
        {
            public override void Bark()
            {
                Console.WriteLine("ISI is not barking like a Dog");
            }
        }
    }
    namespace Abstraction
    {
        /* What is Abstraction?
        --> Hiding the implementation details and only showing what is necessary.
            
        -->Ex..,Think of it like a TV remote
            You press the button → TV changes channel
            You don't know how it works internally — that's hidden
            You only see what it does — that's abstraction */
       
        /* 2 ways to achieve Abstraction in C# 
        1. Abstract Class 
        2. Interface*/

        /* in simple words,
        --> Abstraction is nothing but forcing the child classes,
            to develop the logic behind each functionality ,and parent
            classes to import those functionalities names only, thus 
            the user will see the feature only, or its name only ,
            but not the complete code behind it...

            example..in NodeJs, we use diffrent modules like multer, cloudinary
            jwt, joi etc
            but we dont know the code behind it.
            In short ,we are accessing these modules directly with their names, but the logic 
            behind each name(module) is totally abstracted into diffrent  sub-modules.*/

            /* example...lets create 2 diffrent functions eat and sound()
            thus the eat function will be similiar for every animaal, but sound()
            function will be diffrent for everybody else,like 
            cat meows,dog barks ,Lion Roars */


        abstract class Animal
        {
            public void eat()
            {
                Console.WriteLine("Eating...");
            }
            public abstract void Sound();
        }

        class Dog : Animal
        {
            public override void Sound()
            {
                Console.WriteLine("Dog Barks...");
            }
        }
        class Cat : Animal
        {
            public override void Sound()
            {
                Console.WriteLine("cat Meows...");
            }
        }
        class Lion : Animal
        {
            public override void Sound()
            {
                Console.WriteLine("Lion Roars...");
            }
        }
    }
    /* what is the diffrence between abstract and interface
    
    so we create an abstract class, in which we call an abstract method
    and this abstract method calls the same method , that is 
    written diffrently with diffrent classes using override 
    thus these diffrent classes are the ones that create a seprate logic
    for the same file...*/
    
    class Program
    {
        static void Main(string[]args)
        {
/*             ClassesObjects s1=new ClassesObjects();
            s1.Name="Che Guevara";
            s1.Display();

            Constructor c1= new Constructor("Bhagat Singh",39);
            c1.Run();

            ThisKeyword c2=new ThisKeyword("Che Guevara");
            c2.Display();

            Console.Write("\nEnter the amount :");
            int amnt=int.Parse(Console.ReadLine()!);
            Encapsulation e1=new Encapsulation();
            e1.Deposit(amnt);
            int result=e1.ShowBalance();
            Console.Write($"\nBalance :{result}");
 */
            Dog d1=new Dog();
            d1.Name="ISI";
            d1.Run();
            d1.Bark();

            MethodOverloading  p1=new MethodOverloading();
            Console.WriteLine($"\nAddition:{p1.add(2,5)}");
            Console.WriteLine($"Addition:{p1.add(2,5,7)}");
            Console.WriteLine($"Addition:{p1.add(2.5,5.5)}");
            OverridedDog o1=new OverridedDog();
            o1.Bark();
        }

    }
}