// Select Elements
const taskInput = document.getElementById("taskInput");
const addBtn = document.getElementById("addBtn");
const taskList = document.getElementById("taskList");

// 1️⃣ Add Task Function
const addTask = () => {
    const taskText = taskInput.value.trim();

    if (!taskText) {
        alert("Please enter a task");
        return;
    }

    const li = document.createElement("li");

    li.innerHTML = `
        <span>${taskText}</span>
        <div>
            <button class="completeBtn">✔</button>
            <button class="deleteBtn">❌</button>
        </div>
    `;

    taskList.appendChild(li);
    taskInput.value = "";
};

// 2️⃣ Event Delegation for Delete & Complete
const handleTaskActions = (event) => {

    const target = event.target;

    // Delete Task
    if (target.classList.contains("deleteBtn")) {
        target.closest("li").remove();
    }

    // Mark Complete
    if (target.classList.contains("completeBtn")) {
        const li = target.closest("li");
        li.classList.toggle("completed");
    }
};

// Event Listeners
addBtn.addEventListener("click", addTask);
taskList.addEventListener("click", handleTaskActions);