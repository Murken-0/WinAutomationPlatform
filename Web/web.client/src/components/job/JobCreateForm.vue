<template>
	<form @submit.prevent>
		<h4>Создать задачу</h4>
		<my-input
			v-model="workflow.name"
			type="text"
			placeholder="Название"
		/>
		<div class="form__btns">
			<my-button
				@click="openStudio"
			>
				Открыть студию
			</my-button>

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
				schema: '',
			}
		}
	},
	methods: {
		createWorkflow() {
			this.$emit('createWorkflow', this.workflow)
			this.workflow = {
				name: '',
				scheme: ''
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
	justify-content: space-between;
}

</style>