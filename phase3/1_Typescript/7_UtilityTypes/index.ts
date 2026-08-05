/* 8) Utility Types */

/* JS has no type system, so there's no way to say "same shape but
   all fields optional" or "just these 2 fields" - you'd have to
   write a whole new object shape by hand and keep it in sync.

   TypeScript gives ready-made Utility Types that transform an
   existing type into a new one automatically. */

interface Student {
    name: string;
    age: number;
    cgpa: number;
    college: string;
}

// Partial<T> - makes every field optional
// useful for "update" functions where you only send changed fields
function updateStudent(id: string, updates: Partial<Student>): void {
    console.log(`Updating student ${id} with:`, updates);
}

// Pick<T, Keys> 
type StudentPreview = Pick<Student, "name" | "college">;

function printPreview(preview: StudentPreview): void {
    console.log(`${preview.name} studies at ${preview.college}`);
}

// Omit<T, Keys>
type StudentWithoutCgpa = Omit<Student, "cgpa">;

// Readonly<T>
const frozenStudent: Readonly<Student> = {
    name: "Mangesh",
    age: 23,
    cgpa: 9.59,
    college: "Trinity Academy of Engineering",
};
// frozenStudent.age = 24;   // not allowed

// Record<Keys, ValueType> - object type where every key maps to
// the same value type, good for lookup tables
type GradeBook = Record<string, number>;

const grades: GradeBook = {
    Mangesh: 9.59,
    Rahul: 8.2,
    Priya: 9.1,
};

class Example {
    static run(): void {
        updateStudent("101", { cgpa: 9.7 }); // sending just one field, still valid

        const preview: StudentPreview = { name: "Mangesh", college: "TAE" };
        printPreview(preview);

        const noGpa: StudentWithoutCgpa = {
            name: "Rahul",
            age: 21,
            college: "TAE",
        };
        console.log(`${noGpa.name} - no cgpa needed here`);

        console.log(`Frozen student: ${frozenStudent.name}`);

        for (const student in grades) {
            console.log(`${student}: ${grades[student]}`);
        }
    }
}

Example.run();

export {};