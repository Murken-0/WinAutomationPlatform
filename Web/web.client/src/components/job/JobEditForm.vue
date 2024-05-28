<template>
	<form @submit.prevent>
		<h4>Создать рабочий процесс</h4>
		<my-input
			v-model="workflow.name"
			type="text"
			placeholder="Название"
		/>
		<my-button
			style="align-self: flex-end; margin-top: 15px"
			@click="editWorkflow"
		>
			Создать
		</my-button>
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
		editWorkflow() {
			this.$emit('editWorkflow', this.post)
			this.post = {
				title: '',
				body: ''
			}
		}
	},
}
</script>

<style scoped>
form {
	display: flex;
	flex-direction: column;
}

</style>