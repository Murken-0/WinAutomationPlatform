<template>
	<div v-if="jobs.length > 0">
		<h3>Список задач</h3>
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

</style>