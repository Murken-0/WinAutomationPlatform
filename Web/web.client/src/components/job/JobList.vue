<template>
	<div v-if="jobs.length > 0">
		<h3>Список задач</h3>
		<job-item
			v-for="job in jobs"
			:job="job"
			:key="job.id"
			@deleteJob="$emit('deleteJob', job)"
			@editJob="$emit('editJob', job)"/>
	</div>
	<h2
		v-else
		style="color: red"
	>
		Список пуст
	</h2>
</template>

<script>
import JobItem from "@/components/job/JobItem.vue";

export default {
	components: {JobItem},
	props: {
		jobs: {
			type: Array,
			required: true,
		}
	},
}
</script>

<style scoped>

</style>