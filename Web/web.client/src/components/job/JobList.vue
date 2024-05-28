<template>
	<div v-if="tasks.length > 0">
		<h3>Список задач</h3>
		<task-item
			v-for="task in tasks"
			:job="task"
			:key="task.id"
			@deleteTask="$emit('deleteTask', task)"
			@editTask="$emit('editTask', task)"/>
	</div>
	<h2
		v-else
		style="color: red"
	>
		Список пуст
	</h2>
</template>

<script>
import TaskItem from "@/components/job/JobItem.vue";

export default {
	components: {TaskItem},
	props: {
		tasks: {
			type: Array,
			required: true,
		}
	},
}
</script>

<style scoped>

</style>