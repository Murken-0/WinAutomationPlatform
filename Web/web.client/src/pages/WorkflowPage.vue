<template>
	<div>
		<h1>Рабочие процессы</h1>
		<div class="workflow__btns">
			<my-button
				@click="showCreateDialog">
				Создать рабочий процесс
			</my-button>

			<my-select
				v-model="selectedSort"
				:options="sortOptions"
			/>
		</div>
		<my-dialog
			v-model:show="editVisible">
			<workflow-edit-form @editWorkflow="editWorkflow"/>
		</my-dialog>
		<my-dialog
			v-model:show="createVisible">
			<workflow-create-form @createWorkflow="createWorkflow"/>
		</my-dialog>
		<workflow-list
			v-if="!isWorkflowsLoading"
			:workflows="sortedWorkflows"
			style="margin-top: 20px"
			@deleteWorkflow="deleteWorkflow"
			@editWorkflow="showEditDialog"
		/>
		<div v-else>Загружаем</div>
	</div>
</template>

<script>
import WorkflowList from "@/components/workflow/WorkflowList.vue";
import WorkflowCreateForm from "@/components/workflow/WorkflowCreateForm.vue";
import WorkflowEditForm from "@/components/workflow/WorkflowEditForm.vue";

export default {
	components: {WorkflowList, WorkflowCreateForm, WorkflowEditForm},
	data() {
		return {
			workflows: [
				{
					id: 1,
					name: "Сасный WF",
					lastEdit: new Date().toLocaleString(),
					scheme: "",
				},
				{
					id: 2,
					name: " WF",
					lastEdit: new Date().toLocaleString(),
					scheme: "",
				},
				{
					id: 3,
					name: "Сасный WF",
					lastEdit: new Date(1).toLocaleString(),
					scheme: "",
				},
			],
			createVisible: false,
			editVisible: false,
			isWorkflowsLoading: false,
			selectedSort: '',
			sortOptions: [
				{value: "name", name: "Название"},
				{value: "lastEdit", name: "Дата изменения"},
			]
		}
	},
	methods: {
		showCreateDialog() {
			this.createVisible = true;
		},
		showEditDialog() {
			this.createVisible = true;
		},
		async createWorkflow() {
			this.createVisible = false;
			//await axios.get('https://jsonplaceholder.typicode.com/posts?_limit=10');
			await this.fetchWorkflows();
		},
		async editWorkflow() {
			this.editVisible = false;
			//await axios.get('https://jsonplaceholder.typicode.com/posts?_limit=10');
			await this.fetchWorkflows()
		},
		async deleteWorkflow() {
			//await axios.get('https://jsonplaceholder.typicode.com/posts?_limit=10');
			await this.fetchWorkflows()
		},
		async fetchWorkflows() {
			try {
				this.isWorkflowsLoading = true;
				//const response = await axios.get('https://jsonplaceholder.typicode.com/posts?_limit=10');
				//this.posts = response.data;
			} catch (e) {
				alert(`An error occurred: ${e}`);
			} finally {
				this.isWorkflowsLoading = false;
				let updatedSort = this.selectedSort;
				this.selectedSort = updatedSort;
			}
		},
	},
	mounted() {
		this.fetchWorkflows();
	},
	watch: {
		createVisible(newValue) {
			if (newValue) {
				// Блокировка прокрутки страницы
				document.body.style.overflow = 'hidden';
			} else {
				// Разблокировка прокрутки страницы
				document.body.style.overflow = 'auto';
			}
		},
		editVisible(newValue) {
			if (newValue) {
				// Блокировка прокрутки страницы
				document.body.style.overflow = 'hidden';
			} else {
				// Разблокировка прокрутки страницы
				document.body.style.overflow = 'auto';
			}
		},
	},
	computed: {
		sortedWorkflows() {
			return [...this.workflows].sort((a, b) => {
				return a[this.selectedSort]?.localeCompare(b[this.selectedSort]);
			});
		}
	}
}
</script>

<style scoped>
.workflow__btns {
	margin: 15px 0;
	display: flex;
	justify-content: space-between;
}
</style>