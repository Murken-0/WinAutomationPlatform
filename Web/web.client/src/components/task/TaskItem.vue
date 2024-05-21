<template>
	<div class="task">
		<div>
			<div><strong>Название: </strong> {{ task.name }}</div>
			<div><strong>Статус: </strong> {{ task.status }}</div>
			<br>
			<div><strong>Последее выполнение: </strong> {{ task.lastExecution }}</div>
			<div><strong>Следующее выполнение: </strong> {{ task.nextExecution }}</div>
		</div>
		<div class="task__buttons">
			<my-button>Edit</my-button>
			<my-button @click="$emit('deleteTask', task)" style="margin-top: 10px">Delete</my-button>
		</div>
	</div>
</template>

<script>
import MyButton from "@/components/UI/MyButton.vue";

export default {
	components: {MyButton},
	props: {
		task: {
			type: Object,
			required: true,
		}
	}
}
</script>

<style scoped>
.task {
	padding: 15px;
	border: 2px solid teal;
	border-radius: 5px;
	margin-top: 15px;
	display: flex;
	align-items: center;
	justify-content: space-between;
}

.task__buttons {
	display: flex;
	flex-direction: column;
}
</style>