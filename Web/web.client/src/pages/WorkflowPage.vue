<template>
	<div>
		<h1>Рабочие процессы</h1>
		<div class="workflow__btns">
			<my-button
				@click="showCreateForm">
				Создать
			</my-button>

			<my-select
				v-model="selectedSort"
				:options="sortOptions"
				:label="'Сортировка'"
			/>
		</div>
		<my-dialog
			v-model:show="editVisible">
			<workflow-edit-form
				:wf="selectedWorkflow"
				@save="editWorkflow"
				@changeScript="openStudio"
			/>
		</my-dialog>
		<my-dialog
			v-model:show="createVisible">
			<workflow-create-form @create="createWorkflow"/>
		</my-dialog>
		<workflow-list
			v-if="!isWorkflowsLoading"
			:workflows="sortedWorkflows"
			style="margin-top: 20px"
			@deleteWorkflow="deleteWorkflow"
			@editWorkflow="showEditForm"
		/>
		<div v-else>Загружаем</div>
	</div>
</template>

<script>
import WorkflowList from "@/components/models/workflow/WorkflowList.vue";
import WorkflowCreateForm from "@/components/models/workflow/WorkflowCreateForm.vue";
import WorkflowEditForm from "@/components/models/workflow/WorkflowEditForm.vue";
import axios from "axios";

export default {
	components: {WorkflowList, WorkflowCreateForm, WorkflowEditForm},
	data() {
		return {
			workflows: [],
			createVisible: false,
			editVisible: false,
			isWorkflowsLoading: false,
			selectedSort: '',
			sortOptions: [
				{key: "name", label: "Название"},
				{key: "lastEdit", label: "Дата"},
			],
			selectedWorkflow: {},
		}
	},
	methods: {
		showCreateForm() {
			this.createVisible = true;
		},
		showEditForm(workflow) {
			this.selectedWorkflow = workflow;
			this.editVisible = true;
		},
		async openStudio(workflow) {
			this.$router.push(`/studio/${workflow.id}`);
		},
		async createWorkflow(workflow) {
			this.createVisible = false;
			await axios.post('/api/Workflows/Create', workflow);
			await this.fetchWorkflows();
		},
		async editWorkflow(workflow) {
			this.editVisible = false;
			await axios.put(`/api/Workflows/Update/${workflow.id}`, {
				name: workflow.name,
				script: workflow.script,
			});
			await this.fetchWorkflows()
		},
		async deleteWorkflow(workflow) {
			await axios.delete(`/api/Workflows/Delete/${workflow.id}`);
			await this.fetchWorkflows()
		},
		async fetchWorkflows() {
			try {
				this.isWorkflowsLoading = true;
				const response = await axios.get('/api/Workflows/GetAll');
				this.workflows = response.data;
			} catch (e) {
				alert(`An error occurred: ${e}`);
				console.log(e);
			} finally {
				this.isWorkflowsLoading = false;
			}
		},
	},
	mounted() {
		this.fetchWorkflows();
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
  align-items: center;
}

h1 {
  font-size: 24px;
  font-weight: bold;
  margin-bottom: 10px;
  color: #333;
  user-select: none
}
</style>
