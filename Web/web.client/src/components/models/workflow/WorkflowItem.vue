<template>
	<div class="workflow">
		<div class="workflow_info">
      <div class="workflow__name">{{ workflow.name }}</div>
      <div class="workflow__date">{{ new Date(workflow.lastEdit).toLocaleString("ru-RU") }}</div>
		</div>
		<div class="workflow__buttons">
			<my-button @click="$emit('editWorkflow', workflow)">Редактировать</my-button>
			<my-button @click="$emit('deleteWorkflow', workflow)">Удалить</my-button>
		</div>
	</div>
</template>

<script>
import MyButton from "@/components/UI/MyButton.vue";

export default {
	components: {MyButton},
	props: {
		workflow: {
			type: Object,
			required: true,
		}
	}
}
</script>

<style scoped>
.workflow {
  padding: 15px;
  border: 1px solid #ddd;
  border-radius: 5px;
  display: flex;
  align-items: center;
  justify-content: space-between;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  background-color: #fff;
}

.workflow__buttons {
  display: flex;
  align-items: center;
  gap: 10px;
}

.workflow_info {
  min-width: 100px;
}

.workflow__name {
  font-weight: bold;
}

.workflow__date {
  font-size: 14px;
  color: #777;
}
</style>
