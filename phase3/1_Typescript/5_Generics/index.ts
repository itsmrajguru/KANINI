/* 6) Generics */

/* The core problem in plain JavaScript:
   JS has no compiler and no type system, so there's nothing to
   "reuse type-safely" in the first place. If I want the SAME logic
   to safely work with numbers today and strings tomorrow, JS just
   lets ANY type in silently - no safety, no auto-complete either way.

   TypeScript adds Generics - write the logic ONCE using a
   placeholder type `T`, and TS locks in the real type automatically
   based on whatever gets passed in, keeping full type safety. */


/* 1) Generic Function*/

function getFirstElement<T>(arr: T[]): T {
    return arr[0];
}
// getFirstElement<number>(["a","b"])  <- TS blocks this mismatch


/* 2) Generic Class*/

class Box<T> {
    private value: T;

    constructor(value: T) {
        this.value = value;
    }

    getValue(): T {
        return this.value;
    }
}


/* 3) Generic Constraint - restrict T to only types that have
   a certain property, using `extends`*/

interface HasLength {
    length: number;
}

function printLength<T extends HasLength>(item: T): void {
    console.log(`Length is: ${item.length}`);
}
// printLength(42);   // <- blocked, a plain number has no .length


/* 4) Multiple type parameters*/

function pair<A, B>(first: A, second: B): [A, B] {
    return [first, second];
}


class Example {
    static run(): void {
        console.log("\n-----Generics-----");

        console.log("First number: " + getFirstElement<number>([10, 20, 30]));
        console.log("First name: " + getFirstElement<string>(["Mangesh", "Rahul"]));

        const numberBox = new Box<number>(100);
        console.log("Box value: " + numberBox.getValue());

        printLength("Mangesh");
        printLength([1, 2, 3, 4]);

        const combo = pair<string, number>("Age", 23);
        console.log("Pair: " + combo);
    }
}

Example.run();

export {};
