import { Student } from "./student.model";

// Capitalize name
export function formatName(name: string): string {
    return name.charAt(0).toUpperCase() + name.slice(1).toLowerCase();
}

// Calculate average marks
export function calculateAverage(students: Student[]): number {
    const total = students.reduce((sum, s) => sum + s.marks, 0);
    return total / students.length;
}