/* 2) Interfaces & Type Aliases */

/* The core problem in plain JavaScript:
   JS has ZERO way to say "this object must always have exactly these
   properties, with these types." Any object can have any shape, and
   you only discover a missing/misspelled field when the code tries
   to use it and crashes.

   function printUser(user) {
       console.log(user.naem);  // typo "naem" instead of "name"
       // JS doesn't complain. Just prints "undefined" silently.
   }

   TypeScript fixes this with `interface` and `type` - both let me
   define the exact SHAPE a piece of data must have, and the compiler
   checks every usage against it. */


/* 1) interface - the more common way to describe an object shape*/

interface Student {
    name: string;
    age: number;
    cgpa: number;
    isIntern?: boolean; // the "?" means this field is optional
}

function printStudent(student: Student): void {
    console.log(`${student.name} (${student.age}) - CGPA: ${student.cgpa}`);
}


/* 2) type alias - does almost the same job as interface */

/* Difference people ask about a lot:
   - interface  -> can be "re-opened" later and extended (declaration merging),
                   mainly used for objects/classes
   - type       -> more flexible, can also name unions, primitives,
                   tuples - not just objects

   For a plain object shape like this, either works. I'm using `type`
   here just to show the alternate syntax. */

type Coordinates = {
    lat: number;
    lng: number;
};

function printLocation(loc: Coordinates): void {
    console.log(`Lat: ${loc.lat}, Lng: ${loc.lng}`);
}


/* 3) Interfaces can describe function shapes too, not just objects */
interface MathOperation {
    (a: number, b: number): number;
}

const multiply: MathOperation = (a, b) => a * b;


/* 4) Extending an interface (reusing a shape, adding more to it)*/
interface Intern extends Student {
    company: string;
    stack: string;
}


class Example {
    static run(): void {
        console.log("\n-----Interfaces & Type Aliases-----");

        const s1: Student = { name: "Rahul", age: 21, cgpa: 8.4 };
        printStudent(s1);

        const office: Coordinates = { lat: 18.5204, lng: 73.8567 };
        printLocation(office);

        console.log("Multiply via interface-typed function: " + multiply(4, 5));

        const me: Intern = {
            name: "Mangesh",
            age: 23,
            cgpa: 9.59,
            company: "Kanini Pvt. Ltd.",
            stack: "MERN",
        };
        console.log(`Intern: ${me.name} at ${me.company} (${me.stack})`);
    }
}

Example.run();

export {};
