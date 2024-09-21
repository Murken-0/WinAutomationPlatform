<template>
  <div class="job-list" v-if="jobs.length > 0">
		<job-item
			v-for="job in jobs"
			:job="job"
			:key="job.id"
			@delete="deleteF"
			@edit="edit"
			@execute="execute"
		/>
	</div>
	<h2
		v-else
		style="color: red"
	>
		Список пуст
	</h2>
</template>

<script>
import JobItem from "@/components/models/job/JobItem.vue";

export default {
	components: {JobItem},
	props: {
		jobs: {
			type: Array,
			required: true,
		}
	},
	methods: {
		deleteF(job) {
			this.$emit('delete', job)
		},
		edit(job) {
			this.$emit('edit', job)
		},
		execute(job) {
			this.$emit('execute', job)
		}
	}
}
</script>

<style scoped>
h3 {
  font-size: 20px;
  font-weight: bold;
  margin-bottom: 10px;
  color: #333;
  user-select: none
}

h2 {
  font-size: 18px;
  font-weight: bold;
  color: #dc3545;
  user-select: none
}

.job-list {
  margin-top: 20px;
  display: flex;
  flex-direction: column;
  gap: 20px;
}
</style>