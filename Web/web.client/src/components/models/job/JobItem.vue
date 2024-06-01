<template>
	<div class="job">
		<div class="job__info">
			<div>
				<div><strong>Название: </strong> {{ job.name }}</div>
				<div><strong>Процесс: </strong> {{ job.workflow.name }}</div>
			</div>
			<div class="job__tag" v-show="job.isRecurring">{{ job.cron }}</div>
		</div>
		<div class="job__buttons">
			<my-button @click="$emit('execute', job)">Запустить</my-button>
			<my-button @click="$emit('edit', job)">Редактировать</my-button>
			<my-button @click="$emit('delete', job)">Удалить</my-button>
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
	},
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
	align-items: center;
	justify-content: space-between;
	gap: 10px;
}

.job__info {
	display: flex;
	align-items: center;
	gap: 15px;
}

.job__tag {
	padding: 5px;
	text-align: center;
	background-color: lightgreen;
	border-radius: 10px;
	border: 1px solid teal;
}
</style>