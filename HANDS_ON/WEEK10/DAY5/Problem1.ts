function getFirstElement<T>(items: T[]): T {
    return items[0];
}

interface Repository<T> {
    add(item: T): void;
    getAll(): T[];
}

class DataManager<T> implements Repository<T> {
    private items: T[] = [];

    add(item: T): void {
        this.items.push(item);
    }

    getAll(): T[] {
        return this.items;
    }
}
interface User {
    id: number;
    name: string;
}

interface Product {
    id: number;
    title: string;
}

// User Data Manager
const userManager = new DataManager<User>();

userManager.add({ id: 1, name: "Hemanth" });
userManager.add({ id: 2, name: "Ravi" });

// Product Data Manager
const productManager = new DataManager<Product>();

productManager.add({ id: 101, title: "Laptop" });
productManager.add({ id: 102, title: "Mobile" });

// Display Users
console.log("Users:");
console.log(userManager.getAll());

// Display Products
console.log("Products:");
console.log(productManager.getAll());

// Test Generic Function
const numbers = [10, 20, 30];
const firstNumber = getFirstElement<number>(numbers);

console.log("First Number:", firstNumber);

const users = userManager.getAll();
const firstUser = getFirstElement<User>(users);

console.log("First User:", firstUser);