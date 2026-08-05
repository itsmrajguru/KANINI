/* 3) Union & Intersection Types */

/* The core problem in plain JavaScript:
   A variable can hold ANY value, and if I want it to hold "only a
   couple of specific types", JS has no way to enforce that at all.

   let status = "active";
   status = "banned_from_planet_earth";  // JS: totally fine, no rule broken

   TypeScript fixes this with UNION types (A | B) - restricting a
   value to only be one of a specific, closed set of types/values. */


/* 1) Union Types ( | ) - "this OR that, nothing else" */
type Status = "active" | "inactive" | "banned";

function setStatus(status: Status): void {
    console.log("Status set to: " + status);
}



/* 2) Union of actual TYPES, not just literal values*/
function printId(id: string | number): void {
    console.log("ID: " + id);
}


/* 3) Intersection Types ( & ) - "this AND that, combined into one"*/
interface HasName {
    name: string;
}

interface HasEmail {
    email: string;
}

type Contact = HasName & HasEmail;

function printContact(contact: Contact): void {
    console.log(`${contact.name} <${contact.email}>`);
}


/* 4) A more realistic use of union - API response can be one of
   two different shapes depending on success/failure*/

interface SuccessResponse {
    success: true;
    data: string;
}

interface ErrorResponse {
    success: false;
    error: string;
}

type ApiResponse = SuccessResponse | ErrorResponse;

function handleResponse(response: ApiResponse): void {
    if (response.success) {
        console.log("Data received: " + response.data);
    } else {
        console.log("Error occurred: " + response.error);
    }
}


class Example {
    static run(): void {
        console.log("\n-----Union & Intersection Types-----");

        setStatus("active");
        printId(101);
        printId("EMP-101");

        const contact: Contact = { name: "Mangesh", email: "mangesh@example.com" };
        printContact(contact);

        handleResponse({ success: true, data: "Loaded successfully" });
        handleResponse({ success: false, error: "User not found" });
    }
}

Example.run();
export {};
