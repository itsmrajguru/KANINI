/* 9) unknown vs any */

/* TypeScript has TWO ways to say "I don't know the type yet":
   `any` (turns off type checking completely - dangerous, avoid it)
   `unknown` (forces me to check the type before doing anything with it) */


/* 1) any - basically opts back OUT of TypeScript entirely*/

function processAny(data: any): void {
    console.log(data.toUpperCase()); // compiles fine even though this can crash
}


/* 2) unknown - the safer alternative, TS forces me to NARROW it
   before I'm allowed to use it */

function processUnknown(data: unknown): void {
    // data.toUpperCase();   // <- blocked immediately, TS refuses to compile this

    if (typeof data === "string") {
        console.log(data.toUpperCase()); // now safe, TS knows it's a string here
    } else {
        console.log("Not a string, got: " + typeof data);
    }
}


function parseUserInput(input: unknown): number {
    if (typeof input === "number") {
        return input;
    }
    if (typeof input === "string" && !isNaN(Number(input))) {
        return Number(input);
    }
    throw new Error("Invalid input - expected a number or numeric string");
}


class Example {
    static run(): void {
        console.log("\n-----unknown vs any-----");

        processAny("mangesh"); // works, but ONLY because I got lucky with input type
        processUnknown("mangesh"); // works
        processUnknown(42); // safely handled instead of crashing

        console.log("Parsed: " + parseUserInput("23"));
        console.log("Parsed: " + parseUserInput(23));

        try {
            parseUserInput("not-a-number");
        } catch (error) {
            if (error instanceof Error) {
                console.log("Caught: " + error.message);
            }
        }
    }
}

Example.run();

export {};
