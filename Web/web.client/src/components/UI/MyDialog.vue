<template>
	<div v-if="show"
		class="dialog"
		@click="hideDialog">
		<div class="dialog__content"
			@click.stop>
			<slot></slot>
		</div>
	</div>
</template>

<script>
export default {
	name: 'my-dialog',
	props: {
		show: {
			type: Boolean,
			default: false
		}
	},
	methods: {
		hideDialog() {
			this.$emit('update:show', false);
		}
	}
}
</script>

<style scoped>
.dialog {
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
  position: fixed;
  background: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
}

.dialog__content {
  background-color: #fff;
  border-radius: 12px;
  padding: 20px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.2);
  max-width: 800px;
  min-width: 300px;
  max-height: 80%;
  min-height: 150px;
}

</style>
