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
			<my-button
				@click="createWorkflow"
			>
				Создать
			</my-button>
		</div>
	</form>
</template>

<script>
export default {
	data() {
		return {
			workflow: {
				name: '',
			}
		}
	},
	methods: {
		createWorkflow() {
			this.$emit('create', this.workflow)
			this.workflow = {
				name: '',
			}
		},
	},
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
  justify-content: flex-end;
}

.form__input {
  margin-top: 10px;
}
</style>
