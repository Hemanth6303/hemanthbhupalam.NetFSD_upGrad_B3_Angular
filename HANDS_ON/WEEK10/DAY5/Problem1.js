"use strict";
function getFirstElement(items) {
    return items[0];
}
class DataManager {
    items = [];
    add(item) {
        this.items.push(item);
    }
    getAll() {
        return this.items;
    }
}
// User Data Manager
const userManager = new DataManager();
userManager.add({ id: 1, name: "Hemanth" });
userManager.add({ id: 2, name: "Ravi" });
// Product Data Manager
const productManager = new DataManager();
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
const firstNumber = getFirstElement(numbers);
console.log("First Number:", firstNumber);
const users = userManager.getAll();
const firstUser = getFirstElement(users);
console.log("First User:", firstUser);
