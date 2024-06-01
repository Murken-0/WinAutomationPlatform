<template>
	<form @submit.prevent>
		<h4>Создать задачу</h4>
		<my-input
			v-model="job.name"
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
				@click="createJob"
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
			job: {
				name: '',
				schema: '',
			}
		}
	},
	methods: {
		createJob() {
			this.$emit('createWorkflow', this.job)
			this.job = {
				name: '',
				scheme: ''
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

.form__btns {
	display: flex;
	align-items: center;
	margin-top: 15px;
	justify-content: space-between;
}

</style>