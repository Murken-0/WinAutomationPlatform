<template>
	<div>
		<h1>Задачи</h1>
		<div class="tasks__btns">
			<my-button
				@click="showCreateDialog">
				Создать задачу
			</my-button>

			<my-select
				v-model="selectedSort"
				:options="sortOptions"
				:label="'Сортировка'"
			/>
		</div>
		<my-dialog
			v-model:show="editVisible">
			<task-edit-form :job-prop="selectedJob" @save="editJob"/>
		</my-dialog>
		<my-dialog
			v-model:show="createVisible">
			<task-create-form @createJob="createJob"/>
		</my-dialog>
		<task-list
			v-if="!isJobsLoading"
			:jobs="sortedTasks"
			style="margin-top: 20px"
			@delete="deleteJob"
			@edit="showEditDialog"
			@execute="executeJob"
		/>
		<div v-else>Загружаем</div>
	</div>
</template>

<script>
import axios from "axios";
import TaskList from "@/components/models/job/JobList.vue";
import TaskCreateForm from "@/components/models/job/JobCreateForm.vue";
import TaskEditForm from "@/components/models/job/JobEditForm.vue";

export default {
	components: {TaskCreateForm, TaskEditForm, TaskList},
	data() {
		return {
			jobs: [],
			createVisible: false,
			editVisible: false,
			isJobsLoading: false,
			selectedSort: '',
			sortOptions: [
				{key: "name", label: "Название"},
				{key: 'workflow.name', label: 'Процесс'},
				{key: 'cron', label: 'Cron'},
			],
			selectedJob: {},
		}
	},
	methods: {
		showEditDialog(job) {
			this.selectedJob = job;
			this.editVisible = true;
		},
		showCreateDialog() {
			this.createVisible = true;
		},
		async createJob(job) {
			this.createVisible = false;
			const jobDto = {
				name: job.name,
				workflowId: job.workflowId,
			}
			if (job.isRecurring) {
				jobDto.cron = job.cron;
			}
			await axios.post('/api/Jobs/Create', jobDto);
			await this.fetchJobs()
		},
		async editJob(job) {
			this.editVisible = false;
			const jobDto = {
				name: job.name,
				workflowId: job.workflowId,
			}
			if (job.isRecurring) {
				jobDto.cron = job.cron;
			}
			await axios.put(`/api/Jobs/Update/${job.id}`, jobDto);
			await this.fetchJobs()
		},
		async deleteJob(job) {
			await axios.delete(`/api/Jobs/Delete/${job.id}`);
			await this.fetchJobs()
		},
		async executeJob(job) {
			await axios.post(`/api/Jobs/Execute/${job.id}`);
		},
		async fetchJobs() {
			try {
				this.isJobsLoading = true;
				const response = await axios.get('/api/Jobs/GetAll');
				this.jobs = response.data;
			} catch (e) {
				alert(`An error occurred: ${e}`);
			} finally {
				this.isJobsLoading = false;
			}
		},
	},
	mounted() {
		this.fetchJobs();
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
			return [...this.jobs].sort((a, b) => {
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