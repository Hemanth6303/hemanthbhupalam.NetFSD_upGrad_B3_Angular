// 1. Variable Declaration (Explicit Types)
const userName: string = "Hemanth";
let age: number = 24;
const email: string = "hemanthbhupalam1042@gmail.com";
const isSubscribed: boolean = true;

// 2. Type Inference (No explicit types)
let city = "Anantapur";      // inferred as string
let loginCount = 5;          // inferred as number

// 3. Template Literal (Initial Message)
let userProfileMessage: string = `Hello ${userName}, you are ${age} years old and your email is ${email}.`;

console.log("Initial Profile:");
console.log(userProfileMessage);

// 4. Operators

// Increment age
age++;

// Check premium eligibility
let isEligibleForPremium: boolean = age > 18 && isSubscribed;

// Comparison operator
let isAdult: boolean = age >= 18;

// 5. Updated Template Literal
let updatedProfileMessage: string = `
Updated Profile:
Name: ${userName}
Age: ${age}
Email: ${email}
City: ${city}
Login Count: ${loginCount}
Subscribed: ${isSubscribed}
Eligible for Premium: ${isEligibleForPremium}
Adult: ${isAdult}
`;

// 6. Output
console.log("\nAfter Updates:");
console.log(updatedProfileMessage);