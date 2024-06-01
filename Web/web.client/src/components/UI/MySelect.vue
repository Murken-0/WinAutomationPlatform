<template>
	<select @change="changeOption" class="sort__select">
		<option disabled selected value="">{{ label }}</option>
		<option
			v-for="option in options"
			:key="option.key"
			:value="option.key"
			:selected="option.key === modelValue"
		>{{ option.label }}</option>/
	</select>
</template>

<script>
export default {
	name: 'my-select',
	props: {
		modelValue: {
			type: String,
		},
		label: {
			type: String,
		},
		options: {
			type: Array,
			default: () => [],
		}
	},
	methods: {
		changeOption(event) {
			this.$emit('update:modelValue', event.target.value);
		}
	}
}
</script>

<style scoped>
.sort__select {
	padding: 8px;
	border-radius: 5px;
	border: 2px solid teal;
}
</style>