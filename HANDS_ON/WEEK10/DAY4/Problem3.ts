// 1. Base Class: Employee
class Employee {
    public id: number;
    protected name: string;
    private salary: number;

    constructor(id: number, name: string, salary: number) {
        this.id = id;
        this.name = name;
        this.salary = salary;
    }

    // 2. Getter
    public getSalary(): number {
        return this.salary;
    }

    // 2. Setter with validation
    public setSalary(value: number): void {
        if (value > 0) {
            this.salary = value;
        } else {
            console.log("Salary must be greater than 0");
            //throw new Error("Invalid salary value");
        }
    }

    // 3. Method
    public displayDetails(): void {
        console.log(`Employee ID: ${this.id}`);
        console.log(`Name: ${this.name}`);
        console.log(`Salary: ${this.salary}`);
    }
}

// 4. Derived Class: Manager
class Manager extends Employee {
    public teamSize: number;

    constructor(id: number, name: string, salary: number, teamSize: number) {
        super(id, name, salary); // call base constructor
        this.teamSize = teamSize;
    }

    // 5. Method Overriding
    public displayDetails(): void {
        super.displayDetails(); // reuse parent method
        console.log(`Team Size: ${this.teamSize}`);
    }
}

// 6. Object Creation

// Employee Object
const emp1 = new Employee(101, "Hemanth", 30000);

// Manager Object
const mgr1 = new Manager(201, "Ravi", 60000, 5);

// Using methods
console.log("Employee Details");
emp1.displayDetails();

// Update salary using setter
emp1.setSalary(35000);
console.log("Updated Salary:", emp1.getSalary());

console.log("\nManager Details");
mgr1.displayDetails();