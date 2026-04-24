"use strict";
// 1. Variable Declaration (Explicit Types)
const userName = "Hemanth";
let age = 24;
const email = "hemanthbhupalam1042@gmail.com";
const isSubscribed = true;
// 2. Type Inference (No explicit types)
let city = "Anantapur"; // inferred as string
let loginCount = 5; // inferred as number
// 3. Template Literal (Initial Message)
let userProfileMessage = `Hello ${userName}, you are ${age} years old and your email is ${email}.`;
console.log("Initial Profile:");
console.log(userProfileMessage);
// 4. Operators
// Increment age
age++;
// Check premium eligibility
let isEligibleForPremium = age > 18 && isSubscribed;
// Comparison operator
let isAdult = age >= 18;
// 5. Updated Template Literal
let updatedProfileMessage = `
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
