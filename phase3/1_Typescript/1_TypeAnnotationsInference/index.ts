/* 1) Type Annotations & Inference */

/* The core problem in plain JavaScript:
   let age = 23;
   age = "twenty-three";   <-- JS allows this. No warning, no error.
   Now anything downstream that assumed `age` was a number can break,
   and I won't know until it actually crashes at runtime.

   TypeScript fixes this by "locking" a variable to a type - either
   because I wrote it explicitly, or because TS figured it out on its
   own from the first value I gave it. */


/*1) Explicit Annotation - I tell TS the type myself*/
let age: number = 23;

let name: string = "Mangesh";
let isIntern: boolean = true;


/* 2) Type Inference - I dont write the type, TS figures it out*/
let city = "Pune";
let cgpa = 9.59; 


/*3) Function parameter & return type annotations*/
function add(a: number, b: number): number {
    return a + b;
}

/* 4) Array & Object annotations*/
let scores: number[] = [88, 92, 76];
// scores.push("A+");   // <- blocked, "A+" isn't a number

let student: { name: string; age: number } = {
    name: "Mangesh",
    age: 23,
};


class Example {
    static run(): void {
        console.log("\n-----Type Annotations & Inference-----");
        console.log(`Explicit: ${name}, ${age}, ${isIntern}`);
        console.log(`Inferred: ${city}, ${cgpa}`);
        console.log(`Function result: ${add(5, 3)}`);
        console.log(`Array: ${scores}`);
        console.log(`Object: ${student.name}, ${student.age}`);
    }
}

Example.run();

export {};
