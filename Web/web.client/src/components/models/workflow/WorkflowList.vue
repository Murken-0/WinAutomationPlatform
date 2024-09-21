<template>
  <div class="workflow-list" v-if="workflows.length > 0">
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
import WorkflowItem from "@/components/models/workflow/WorkflowItem.vue";

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

.workflow-list {
  margin-top: 20px;
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(400px, 1fr));
  gap: 20px;
}
</style>
