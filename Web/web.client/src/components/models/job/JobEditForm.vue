<template>
	<form @submit.prevent>
		<h4>Редактировать задачу</h4>
		<my-input
			v-model="job.name"
			placeholder="Название"
			type="text"
		/>
		<my-select
			v-model="job.workflowId"
			:options="workflows"
			:label="'Рабочий процесс'"
		/>
		<cron-light
			v-model="job.cron"
			:class="{ inactive: !job.isRecurring}"
			class="form__cron"
			@error="cronError"
		/>

		<div class="form__btns">
			<div class="form__btns__recurring">
				<div class="form__checker">
					<input
						id="recurring"
						v-model="job.isRecurring"
						type="checkbox"
						value="Повторяющаяся"
					/>
					<label for="recurring">Повторяющаяся</label>
				</div>
				<div class="cron" v-show="job.isRecurring">{{ job.cron }}</div>
			</div>
			<my-button
				@click="save"
			>
				Сохранить
			</my-button>
		</div>
	</form>
</template>

<script>
import '@vue-js-cron/light/dist/light.css'

import axios from "axios";
import {CronLight} from '@vue-js-cron/light'

export default {
	components: {CronLight},
	data() {
		return {
			job: {},
			workflows: [],
		}
	},
	props: {
		jobProp: {
			type: Object,
			required: true,
		}
	},
	methods: {
		save() {
			this.$emit('save', this.job)
			this.job = {};
		},
		async fetchWorkflows() {
			try {
				const response = await axios.get('/api/Workflows/GetAll');
				this.workflows = response.data.map((item) => {
					return {
						key: item.id,
						label: item.name,
					}
				});
			} catch (e) {
				alert(`An error occurred: ${e}`);
				console.log(e);
			}
		},
		cronError(event) {
			console.log(event);
		}
	},
	watch: {
		jobProp: {
			immediate: true,
			handler(newVal) {
				this.job = {};
				Object.assign(this.job, newVal)
				console.log(this.job)

			}
		}
	},
	mounted() {
		this.fetchWorkflows();
	},
}
</script>

<style scoped>
form {
  display: flex;
  flex-direction: column;
  gap: 10px;
}

h4 {
  font-size: 18px;
  font-weight: bold;
  text-align: center;
  color: #333; /* Цвет заголовка */
}

.form__btns {
  display: flex;
  align-items: center;
  justify-content: space-between;
  gap: 20px;
}

.form__btns__recurring {
  display: flex;
  align-items: center;
  gap: 20px;
}

.form__checker {
  display: flex;
  align-items: center;
  gap: 5px;
  padding: 8px;
  border: 1px solid #ddd; /*  Тонкая рамка */
  border-radius: 5px;
  background-color: #fff; /*  Белый фон */
}

.form__cron {
  padding: 8px;
  border: 1px solid #ddd; /*  Тонкая рамка */
  border-radius: 5px;
  background-color: #fff; /*  Белый фон */
  min-width: 350px;
}

.inactive {
  opacity: 0.4;
  border: 1px solid #ddd; /*  Тонкая рамка */
  pointer-events: none;
}

.cron {
  padding: 0 10px;
  text-align: center;
  background-color: #e0ffe3; /*  Светло-зеленый фон */
  border-radius: 10px;
  border: 1px solid #ddd; /*  Тонкая рамка */
}
</style>