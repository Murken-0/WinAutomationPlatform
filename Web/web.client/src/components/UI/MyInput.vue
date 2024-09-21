<template>
	<input :value="modelValue" @input="updateInput" class="input" type="text">
</template>

<script>
export default {
	name: "my-input",
	props: {
		modelValue: [String, Number],
	},
	methods: {
		updateInput(event) {
			this.$emit("update:modelValue", event.target.value);
		}
	}
}
</script>

<style scoped>
.input {
  width: 100%;
  border: 1px solid #ddd;
  border-radius: 5px;
  padding: 8px 15px;
  background-color: #fff;
  color: #333;
  font-size: 14px;
}

.input::placeholder {
  color: #aaa;
}

.input:focus {
  outline: none;
  box-shadow: 0 0 0 2px #007bff;
  transition: box-shadow 0.2s ease;
}
</style>
