/* 7) Access Modifiers (private / protected / readonly) */

/* In JS, there's no real "private" thing.
   Even if you write _balance to show "don't touch this", people
   can still access it from outside directly. JS doesn't stop them.

   class Account {
       constructor() { this._balance = 0; }
   }
   const acc = new Account();
   acc._balance = 999999;   // JS allows this, no error at all

   In TypeScript, private/protected/readonly are REAL. If I mark
   something private, the compiler itself blocks outside access. */

// private - can only be used inside this same class
class BankAccount {
    private balance: number = 0;

    deposit(amount: number): void {
        if (amount > 0) this.balance += amount;
    }

    getBalance(): number {
        return this.balance;
    }
}
// acc.balance = 999999;   // not allowed, balance is private

// protected - usable inside this class + any child class, but not outside
class Employee {
    protected salary: number;

    constructor(salary: number) {
        this.salary = salary;
    }
}

class Manager extends Employee {
    giveBonus(amount: number): void {
        this.salary += amount; // works because Manager extends Employee
        console.log("New salary: " + this.salary);
    }
}
// e.salary = 100000;   // not allowed from outside

// readonly - set once, can't change after that
class Student {
    readonly rollNumber: string;
    name: string;

    constructor(rollNumber: string, name: string) {
        this.rollNumber = rollNumber;
        this.name = name;
    }
}
// s.rollNumber = "TAE-999";   // not allowed, readonly locked after constructor

// shortcut - write access modifier directly in constructor params,
// no need to write this.name = name manually
class Product {
    constructor(
        public name: string,
        private price: number,
        readonly sku: string
    ) {}

    getPrice(): number {
        return this.price;
    }
}

class Example {
    static run(): void {
        const acc = new BankAccount();
        acc.deposit(500);
        console.log("Balance: " + acc.getBalance());

        const mgr = new Manager(60000);
        mgr.giveBonus(5000);

        const s1 = new Student("TAE-101", "Mangesh");
        console.log(`Roll No: ${s1.rollNumber}, Name: ${s1.name}`);

        const p1 = new Product("Keyboard", 2500, "SKU-001");
        console.log(`${p1.name} (${p1.sku}) - Price: ${p1.getPrice()}`);
    }
}

Example.run();

export {};