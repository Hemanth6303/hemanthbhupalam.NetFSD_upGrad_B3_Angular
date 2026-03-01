import { addTask, deleteTask, listTasks } from "./storage.js";

const taskInput = document.getElementById("taskInput");
const addBtn = document.getElementById("addBtn");
const taskList = document.getElementById("taskList");

const renderTasks = async () => {
    const tasks = await listTasks();

    taskList.innerHTML = tasks.map(task => `
        <li>
            ${task.text}
            <button data-id="${task.id}">Delete</button>
        </li>
    `).join("");
};

addBtn.addEventListener("click", async () => {
    const text = taskInput.value.trim();

    if (!text) {
        alert("Please enter a task");
        return;
    }

    try {
        await addTask(text);
        taskInput.value = "";
        await renderTasks();
    } catch (error) {
        console.error(`Error: ${error}`);
    }
});

taskList.addEventListener("click", async (e) => {
    if (e.target.tagName === "BUTTON") {
        const id = Number(e.target.dataset.id);

        try {
            await deleteTask(id);
            await renderTasks();
        } catch (error) {
            console.error(`Error: ${error}`);
        }
    }
});

// Initial Load
renderTasks();