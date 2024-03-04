function openTab(evt, tabName) {
    var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }
    document.getElementById(tabName).style.display = "block";
    evt.currentTarget.className += " active";

    if (tabName === 'lista') {
        getAllTask();
    }
}

function getAllTask() {
    fetch('/api/Task', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => {

            if (!response.ok) {
                throw new Error('Erro ao trazer as tarefas');
            }
            return response.json();

        })
        .then(data => {

            const taskList = document.getElementById('task-list');
            const completedTaskList = document.getElementById('completed-task-list');

            taskList.innerHTML = '';
            completedTaskList.innerHTML = '';

            data.forEach(task => {
                const taskItem = document.createElement('li');
                taskItem.classList.add('task-item');

                // Adiciona estilo de tarefa concluída ou incompleta
                if (task.isCompleted) {
                    taskItem.classList.add('completed-task');
                }

                taskItem.textContent = task.tasks;

                taskItem.addEventListener('click', () => openTaskDetails(task));

                if (task.isCompleted) {
                    completedTaskList.appendChild(taskItem);
                } else {
                    taskList.appendChild(taskItem);
                }
            });
        })
        .catch(error => {
            console.error('Erro:', error);
        });
}

function addTask() {
    var taskInput = document.getElementById("new-task").value;

    var taskData = {
        tasks: taskInput,
    };

    fetch('/api/Task', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(taskData)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Erro ao adicionar tarefa');
            }
            Swal.fire({
                icon: 'success',
                title: 'Tarefa Adicionada!',
                text: 'A tarefa foi adicionada com sucesso na lista de tarefas.',
            });

            document.getElementById("new-task").value = '';

            getAllTask();
            return response.json();
        })
        .catch(error => {
            console.error('Erro:', error);
        });
}

function openTaskDetails(task) {

    Swal.fire({
        title: 'Detalhes da Tarefa',
        html: `
        <p><strong>ID:</strong> ${task.id}</p>
        <p><strong>Tarefa:</strong> ${task.tasks}</p>
        <p><strong>Situacao:</strong> ${task.isCompleted ? 'Completa' : 'Incompleta'}</p>
    `,
        showCancelButton: false,
        didOpen: () => {
            Swal.getActions().querySelector('.swal2-confirm').insertAdjacentHTML('afterend', `
            <button class="swal2-confirm swal2-styled" style="background-color:#d33" onclick="deleteTask(${task.id})">Exluir Tarefa</button>
            <button class="swal2-confirm swal2-styled" onclick="toggleTaskStatus(${task.id})">Mudar Status da Tarefa</button>
        `);
        }
    });

}


function deleteTask(taskId) {
    fetch(`/api/Task/${taskId}`, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => {

            if (!response.ok) {
                throw new Error('Erro ao remover a tarefa');
            }
            Swal.fire({
                icon: 'success',
                title: 'Tarefa Removida!',
                text: 'A tarefa foi removida.',
            });

            getAllTask();
        })
        .catch(error => {
            console.error('Erro:', error);
        });
}

function toggleTaskStatus(taskId) {
    fetch(`/api/Task/${taskId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Erro ao alterar o status da tarefa');
            }
            Swal.fire({
                icon: 'success',
                title: 'Tarefa Atualizada!',
                text: 'O status da tarefa foi atualizado com sucesso.',
            });

            getAllTask();
        })
        .catch(error => {
            console.error('Erro:', error);
        });
}


