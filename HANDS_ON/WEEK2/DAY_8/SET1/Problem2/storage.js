// storage.js

let tasks = [];

export const addTask = (taskText) => {
    return new Promise((resolve) => {
        setTimeout(() => {
            const newTask = {
                id: Date.now(),
                text: taskText
            };
            tasks.push(newTask);
            resolve(newTask);
        }, 500);
    });
};

export const deleteTask = (id) => {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            const index = tasks.findIndex(task => task.id === id);

            if (index !== -1) {
                const removed = tasks.splice(index, 1);
                resolve(removed[0]);
            } else {
                reject("Task not found");
            }
        }, 500);
    });
};

export const listTasks = () => {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve(tasks);
        }, 500);
    });
};