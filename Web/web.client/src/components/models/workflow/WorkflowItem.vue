<template>
	<div class="workflow">
		<div>
			<div><strong>Название: </strong> {{ workflow.name }}</div>
			<div><strong>Дата изменения: </strong> {{ new Date(workflow.lastEdit).toLocaleString("ru-RU") }}</div>
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
	border: 2px solid teal;
	border-radius: 5px;
	margin-top: 15px;
	display: flex;
	align-items: center;
	justify-content: space-between;
}

.workflow__buttons {
	display: flex;
	align-items: center;
	justify-content: space-between;
	gap: 10px;
}
</style>