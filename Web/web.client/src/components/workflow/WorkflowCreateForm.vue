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
				lastEdit: '',
				version: '',
				scheme: ''
			}
		}
	},
	methods: {
		createWorkflow() {
			this.workflow.lastEdit = new Date(Date.now()).toISOString();
			this.workflow.version = 0;
			this.$emit('createWorkflow', this.workflow)
			this.workflow = {
				name: '',
				lastEdit: '',
				version: '',
				scheme: '',
			}
		},
		openStudio() {
			this.$emit('openStudio', this.workflow)
		},
	},
}
</script>

<style scoped>
form {
	display: flex;
	flex-direction: column;
}

.form__btns {
	display: flex;
	align-items: center;
	margin-top: 15px;
	justify-content: flex-end;
}

.form__input {
	margin-top: 10px;
}

</style>