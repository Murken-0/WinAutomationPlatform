<template>
	<div class="job">
		<div>
			<div><strong>Название: </strong> {{ job.name }}</div>
			<div><strong>Статус: </strong> {{ job.status }}</div>
			<br>
			<div><strong>Последее выполнение: </strong> {{ job.lastExecution }}</div>
			<div><strong>Следующее выполнение: </strong> {{ job.nextExecution }}</div>
		</div>
		<div class="job__buttons">
			<my-button>Edit</my-button>
			<my-button @click="$emit('deleteJob', job)" style="margin-top: 10px">Delete</my-button>
		</div>
	</div>
</template>

<script>
import MyButton from "@/components/UI/MyButton.vue";

export default {
	components: {MyButton},
	props: {
		job: {
			type: Object,
			required: true,
		}
	}
}
</script>

<style scoped>
.job {
	padding: 15px;
	border: 2px solid teal;
	border-radius: 5px;
	margin-top: 15px;
	display: flex;
	align-items: center;
	justify-content: space-between;
}

.job__buttons {
	display: flex;
	flex-direction: column;
}
</style>