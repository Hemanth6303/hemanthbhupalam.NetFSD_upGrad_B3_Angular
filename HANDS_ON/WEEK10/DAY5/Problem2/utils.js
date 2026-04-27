// Capitalize name
export function formatName(name) {
    return name.charAt(0).toUpperCase() + name.slice(1).toLowerCase();
}
// Calculate average marks
export function calculateAverage(students) {
    const total = students.reduce((sum, s) => sum + s.marks, 0);
    return total / students.length;
}
