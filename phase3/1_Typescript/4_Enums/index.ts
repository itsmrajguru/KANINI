/* 5) Enums */

/* The core problem in plain JavaScript:
   JS has NO enum keyword at all. People fake it with plain objects
   or just raw strings scattered everywhere in the codebase:

   const status = "ACTIVE";      // typo-prone, no auto-complete,
   if (status === "Active") {}   // this silently never matches (case mismatch)
                                  // and JS won't warn me at all

   TypeScript adds a real `enum` type - a fixed, named set of
   constants, with auto-complete and compile-time checking. */


/* 1) Numeric Enum - each member auto-gets a number (starting at 0)*/
enum Status {
    Active, // 0
    Inactive, // 1
    Banned, // 2
}

function printStatus(status: Status): void {
    console.log("Status: " + Status[status]); // Status[0] -> "Active"
}


/* 2) String Enum - more readable when logging/debugging*/
enum Role {
    Admin = "ADMIN",
    Intern = "INTERN",
    Guest = "GUEST",
}

function printRole(role: Role): void {
    console.log("Role: " + role);
}


/* 4) Using enums inside a switch (very common real pattern)*/
function getPermissionLevel(role: Role): number {
    switch (role) {
        case Role.Admin:
            return 3;
        case Role.Intern:
            return 2;
        case Role.Guest:
            return 1;
    }
}

class Example {
    static run(): void {
        console.log("\n-----Enums-----");

        printStatus(Status.Active);
        printStatus(Status.Banned);

        printRole(Role.Admin);
        printRole(Role.Intern);

        console.log("Admin permission level: " + getPermissionLevel(Role.Admin));
        console.log("Guest permission level: " + getPermissionLevel(Role.Guest));
    }
}

Example.run();

export {};
