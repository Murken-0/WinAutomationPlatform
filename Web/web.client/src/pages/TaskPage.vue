<template>
	<div>
		<h1>Задачи</h1>
		<div class="tasks__btns">
			<my-button
				@click="showDialog">
				Создать задачу
			</my-button>

			<my-select
				v-model="selectedSort"
				:options="sortOptions"
			/>
		</div>
		<my-dialog
			v-model:show="editVisible">
			<task-edit-form @editTask="editTask"/>
		</my-dialog>
		<my-dialog
			v-model:show="createVisible">
			<task-create-form @createTask="createTask"/>
		</my-dialog>
		<task-list
			v-if="!isTasksLoading"
			:tasks="sortedTasks"
			style="margin-top: 20px"
			@deleteTask="deleteTask"
		/>
		<div v-else>Загружаем</div>
	</div>
</template>

<script>
import axios from "axios";
import TaskList from "@/components/task/TaskList.vue";
import TaskCreateForm from "@/components/task/TaskCreateForm.vue";
import TaskEditForm from "@/components/task/TaskEditForm.vue";

export default {
	components: {TaskCreateForm, TaskEditForm, TaskList},
	data() {
		return {
			tasks: [
				{
					id: 1,
					name: 'Сасная',
					status: 'Завершена',
					lastExecution: new Date().toLocaleString(),
					nextExecution: 'Не определено',
				},
				{
					id: 1,
					name: 'Ласная',
					status: 'Выполняется',
					lastExecution: new Date().toLocaleString(),
					nextExecution: 'Не определено',
				},
				{
					id: 1,
					name: 'Сасная',
					status: 'Ошибка',
					lastExecution: new Date(1).toLocaleString(),
					nextExecution: 'Не определено',
				},
				{
					id: 1,
					name: 'Сасная',
					status: 'Выполняется',
					lastExecution: new Date(1).toLocaleString(),
					nextExecution: 'Не определено',
				}
			],
			createVisible: false,
			editVisible: false,
			isTasksLoading: false,
			selectedSort: '',
			sortOptions: [
				{value: "name", name: "по имени"},
				{value: "status", name: "по статусу"},
			]
		}
	},
	methods: {
		showEditDialog() {
			this.editVisible = true;
		},
		showCreateDialog() {
			this.createVisible = true;
		},
		async createTask(task) {
			this.createVisible = false;
			//await axios.get('https://jsonplaceholder.typicode.com/posts?_limit=10');
			await this.fetchWorkflows()
		},
		async editTask(task) {
			this.createVisible = false;
			//await axios.get('https://jsonplaceholder.typicode.com/posts?_limit=10');
			await this.fetchWorkflows()
		},
		async deleteTask(task) {
			//await axios.get('https://jsonplaceholder.typicode.com/posts?_limit=10');
			await this.fetchWorkflows()
		},
		async fetchTasks() {
			try {
				this.isTasksLoading = true;
				//const response = await axios.get('https://jsonplaceholder.typicode.com/posts?_limit=10');
				//this.posts = response.data;
			} catch (e) {
				alert(`An error occurred: ${e}`);
			} finally {
				this.isTasksLoading = false;
				let updatedSort = this.selectedSort;
				this.selectedSort = updatedSort;
			}
		},
	},
	mounted() {
		this.fetchTasks();
	},
	watch: {
		createVisible(newValue) {
			if (newValue) {
				document.body.style.overflow = 'hidden';
			} else {
				document.body.style.overflow = 'auto';
			}
		},
		editVisible(newValue) {
			if (newValue) {
				document.body.style.overflow = 'hidden';
			} else {
				document.body.style.overflow = 'auto';
			}
		},
	},
	computed: {
		sortedTasks() {
			return [...this.tasks].sort((a, b) => {
				return a[this.selectedSort]?.localeCompare(b[this.selectedSort]);
			});
		}
	}
}
</script>

<style scoped>
.tasks__btns {
	margin: 15px 0;
	display: flex;
	justify-content: space-between;
}
</style>