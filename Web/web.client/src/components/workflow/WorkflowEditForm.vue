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
			if (JSON.stringify(this.workflow) !== JSON.stringify(this.wf)) {
				this.workflow.lastEdit = new Date(Date.now()).toISOString();
				this.workflow.version += 1;
			}
			this.$emit('save', this.workflow)
			this.workflow = {};
		},
		changeScript() {
			if (JSON.stringify(this.workflow) === JSON.stringify(this.wf)) {
				this.workflow.lastEdit = new Date(Date.now()).toISOString();
				this.workflow.version += 1;
			}
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

.form__input {
	margin-top: 10px;
}

.form__btns {
	display: flex;
	justify-content: space-between;
	margin-top: 15px;
}

</style>