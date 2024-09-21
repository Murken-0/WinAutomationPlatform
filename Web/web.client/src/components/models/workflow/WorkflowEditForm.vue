<template>
	<form @submit.prevent>
		<h4>Создать рабочий процесс</h4>
		<my-input
			v-model="workflow.name"
			type="text"
			placeholder="Название"
			class="form__input"
		/>

		<div class="form__btns">
			<my-button @click="changeScript">
				Изменить скрипт
			</my-button>

			<my-button @click="save">
				Сохранить
			</my-button>
		</div>
	</form>
</template>

<script>
export default {
	data() {
		return {
			workflow: {},
		}
	},
	props: {
		wf: {
			type: Object,
			required: true,
		}
	},
	methods: {
		save() {
			this.$emit('save', this.workflow)
			this.workflow = {};
		},
		changeScript() {
			this.$emit('changeScript', this.workflow);
			this.workflow = {};
		}
	},
	watch: {
		wf: {
			immediate: true,
			handler(newVal) {
				this.workflow = {};
				Object.assign(this.workflow, newVal)
			}
		}
	}
}
</script>

<style scoped>
form {
  display: flex;
  flex-direction: column;
}

h4 {
  font-size: 18px;
  font-weight: bold;
  color: #333;
  text-align: center;
}

.form__btns {
  display: flex;
  align-items: center;
  margin-top: 10px;
  justify-content: space-between;
}

.form__input {
  margin-top: 10px;
}

</style>