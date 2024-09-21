<template>
	<div class="job">
		<div class="job__info">
			<div>
        <div class="job__name">{{ job.name }}</div>
        <div class="job__workflow">{{ job.workflow.name }}</div>
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
  border: 1px solid #ddd; /*  Светлая рамка */
  border-radius: 5px;
  display: flex;
  align-items: center;
  justify-content: space-between;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1); /*  Добавляем тень */
  background-color: #fff; /*  Белый фон */
}

.job__info {
  display: flex;
  align-items: center;
  gap: 15px;
}

.job__tag {
  padding: 5px 10px;
  border-radius: 5px;
  background-color: #e0ffe3; /* Светло-зеленый фон */
  color: #333;
}

.job__name {
  font-weight: bold;
}

.job__workflow {
  font-size: 14px;
  color: #777; /*  Серый цвет для названия процесса */
}

.job__buttons {
  display: flex;
  align-items: center;
  gap: 10px;
}
</style>
