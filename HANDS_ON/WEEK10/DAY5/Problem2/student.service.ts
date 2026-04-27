import { Student } from "./student.model";
import { PASS_MARKS } from "./constants";


// Function to calculate grade
export function getGrade(marks: number): string {
    if (marks >= 90) return "A+";
    if (marks >= 75) return "A";
    if (marks >= 60) return "B";
    if (marks >= PASS_MARKS) return "C";
    return "Fail";
}

// Function to find topper
export function getTopper(students: Student[]): Student {
    return students.reduce((topper, current) =>
        current.marks > topper.marks ? current : topper
    );
}