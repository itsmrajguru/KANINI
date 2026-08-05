/* 10) Strict Null Checking */

/* Problem in JS: null/undefined can sneak into any variable, and JS
   lets you call methods on them - which crashes at runtime.

   function greet(name) {
       return "Hello " + name.toUpperCase();
   }
   greet(undefined); // crashes, no warning before running

   TypeScript's strictNullChecks forces me to handle null/undefined
   before the code is even allowed to compile. */

function greetSafe(name: string | null): string {
    if (name === null) {
        return "Hello Guest";
    }
    return "Hello " + name.toUpperCase();
}

/* Optional chaining (?.) - safely read a nested value that might
   not exist, without writing a big if-check. */

interface Profile {
    name: string;
    city?: string;
}

function printCity(profile: Profile): void {
    console.log("City: " + (profile.city ?? "Not provided"));
}

/* Nullish coalescing (??) - fallback only when the value is
   null/undefined. Unlike `||`, it does NOT replace 0, "", or false. */

function getDiscount(discount: number | null): number {
    return discount ?? 5; // discount || 5 would wrongly turn a real 0 into 5
}

class Example {
    static run(): void {
        console.log(greetSafe("Mangesh"));
        console.log(greetSafe(null));

        printCity({ name: "Mangesh", city: "Pune" });
        printCity({ name: "Rahul" });

        console.log("Discount (0): " + getDiscount(0));
        console.log("Discount (none): " + getDiscount(null));
    }
}

Example.run();

export {};