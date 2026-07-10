



1) Access Specifier
   C++  -> Members are private by default inside a class.
   C#   -> Members are also private by default.
           If we want to access them from another class,
           we have to write public.
           
    <note>By default, a method without an access modifier is private.so it is must to add public 
    as a access specifier , when needed


2) Object Creation
   C++  -> Object can be created simply.

           Student s;

   C#   -> Object is created using new keyword.

           Student s = new Student();

3) Calling Methods
   If the method is NON-STATIC

   C++  -> Call using object.
   C#   -> Call using object.

           Student s = new Student();
           s.Display();

4) Constructors
    C++ -> Constructor name = Class name.
    C#  -> Same rule.

5) Destructor
    C++ -> We can write destructor.

            ~Student()

    C#  -> Destructor exists but is rarely used because
            Garbage Collector manages memory