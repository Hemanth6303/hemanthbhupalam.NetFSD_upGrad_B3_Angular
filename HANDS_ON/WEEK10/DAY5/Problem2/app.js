import { getGrade, getTopper } from "./student.service.js";
import { formatName, calculateAverage } from "./utils.js";
// Sample Data
const students = [
    { id: 1, name: "hemanth", marks: 85 },
    { id: 2, name: "ravi", marks: 92 },
    { id: 3, name: "sita", marks: 67 }
];
// Formatted Names
console.log("Formatted Names:");
students.forEach(s => {
    console.log(formatName(s.name));
});
// Grades
console.log("\nGrades:");
students.forEach(s => {
    console.log(`${s.name}: ${getGrade(s.marks)}`);
});
// Average Marks
const avg = calculateAverage(students);
console.log("\nAverage Marks:", avg);
// Topper
const topper = getTopper(students);
console.log("\nTopper:", topper);
