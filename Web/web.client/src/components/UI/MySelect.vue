<template>
	<select @change="changeOption" class="sort__select">
		<option disabled selected value="">Сортировка</option>
		<option
			v-for="option in options"
			:key="option.value"
			:value="option.value"
		>{{ option.name }}</option>/
	</select>
</template>

<script>
export default {
	name: 'my-select',
	props: {
		modelValue: {
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
	border-radius: 5px;
}
</style>