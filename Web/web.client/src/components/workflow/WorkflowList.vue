<template>
	<div v-if="workflows.length > 0">
		<h3>Список рабочих процессов</h3>
		<workflow-item
			v-for="workflow in workflows"
			:workflow="workflow"
			:key="workflow.id"
			@editWorkflow="editWorkflow"
			@deleteWorkflow="deleteWorkflow"/>
	</div>
	<h2
		v-else
		style="color: red"
	>
		Список пуст
	</h2>
</template>
<script>
import WorkflowItem from "@/components/workflow/WorkflowItem.vue";

export default {
	components: {WorkflowItem},
	props: {
		workflows: {
			type: Array,
			required: true,
		}
	},
	methods: {
		editWorkflow(workflow) {
			this.$emit('editWorkflow', workflow)
		},
		deleteWorkflow(workflow) {
			this.$emit('deleteWorkflow', workflow)
		}
	}
}
</script>
<style scoped>

</style>