/* Synchronous & Asynchronus Programming 

Suppose your program needs to:
Fetch data from a database, Call an API And Read a large file.

Console.WriteLine("Start");
GetData();   // Takes 5 seconds
Console.WriteLine("End");

These operations take time.

Thus C# will assign this task to a specific thread

1) Synchronous Programming :
--> It will first wait for method GetData() to return output,
but as itwill need time to process such a big file and return so much data,
the thread will say Goodbye and move on to execute the next commands. 

2) Aynchronus Programming :
--> Instead of waiting, the thread says:
"Database, do your work. I'll continue with other tasks. Tell me when you're done." 
I'll come to you ,and return your output to the user */

/* Actual Meaning of Async and Await
a) Async --> says this method/aur function contains some Asynchronus operation
b) await --> says , wait at this line until it is executed,
             but at the same time dont block the thread ,continue some another operation */


/* Differnce between JS and C#
1) IN C# sharp you replace function by Task
2) you have to mention the return type infront of Task Keyword
or simply you can mention <T> that will be used by the user as per choice */

using System;
using System.Threading.Tasks; //essential for Async Await
namespace AsyncAwait
{
    /* yeh ek Asynchronus method hai, jo kuch return nahi karta,
    isliye return type "Task" hai (JS ke Promise<void> jaisa) */
    public async Task GetDataAsync()
    {
        Console.WriteLine("Database se data laana shuru...");

        /* Task.Delay() -> jaise JS ka setTimeout, yeh simulate karta hai
        ki database/API call ko time lag raha hai (yahan 3 second)
        await -> is line pe ruk, lekin thread ko block mat kar,
        doosra kaam chalne de tab tak */
        await Task.Delay(3000);

        Console.WriteLine("Data mil gaya Database se!");
    }

    /* yeh method kuch return kar raha hai (string), isliye
    return type "Task<string>" hai (JS ke Promise<string> jaisa) */
    public async Task<string> GetUserNameAsync()
    {
        await Task.Delay(2000);   // 2 second ka API call simulate kiya
        return "Mangesh Rajguru";
    }

    public async Task Run()
    {
        Console.WriteLine("Run() shuru hua");

        // yahan await lagaya, isliye yeh line tab tak rukegi jab tak
        // GetDataAsync() poora na ho jaaye, lekin thread free rahega
        await GetDataAsync();

        // yeh method string return kar raha hai, usko variable mein store kiya
        string name = await GetUserNameAsync();
        Console.WriteLine("User ka naam: " + name);

        Console.WriteLine("Run() khatam hua");
    }
    class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Async & await---");
            Example e1=new Example();
            e1.Run();
        }
    }
}