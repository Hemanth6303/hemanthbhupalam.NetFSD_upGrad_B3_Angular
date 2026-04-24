"use strict";
// 1. Function with Required Parameter
function getWelcomeMessage(name) {
    return `Welcome ${name}!`;
}
// 2. Optional Parameter
function getUserInfo(name, age) {
    //console.log(age);
    if (age !== undefined) {
        return `User ${name} is ${age} years old.`;
    }
    return `User ${name} has not provided age.`;
}
// 3. Default Parameter
function getSubscriptionStatus(name, isSubscribed = false) {
    return isSubscribed
        ? `${name} is subscribed to our services.`
        : `${name} is not subscribed.`; //ternery operator
}
// 4. Function with Boolean Return Type
function isEligibleForPremium(age) {
    return age > 18;
}
// 5. Arrow Function (rewritten version)
const getAccountStatus = (name, isActive) => {
    return isActive
        ? `${name}'s account is active.`
        : `${name}'s account is inactive.`;
};
// 6. Lexical 'this' using Arrow Function
const notificationService = {
    appName: "ShopEZ",
    // Arrow function preserves 'this'
    sendNotification: (userName) => {
        return `Hello ${userName}, welcome to ${notificationService.appName}!`;
    }
};
// 7. Execution
const name1 = "Hemanth";
const age = 22;
console.log(getWelcomeMessage(name1));
console.log(getUserInfo(name1, age));
console.log(getUserInfo(name1)); // without age
console.log(getSubscriptionStatus(name1, true));
console.log(getSubscriptionStatus(name1)); // default false
console.log(`Eligible for Premium: ${isEligibleForPremium(age)}`);
console.log(getAccountStatus(name1, true));
console.log(notificationService.sendNotification(name1));
